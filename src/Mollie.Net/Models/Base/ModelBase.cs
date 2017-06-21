using Mollie.Net.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Net.Models.Base
{
    public abstract partial class ModelBase : INotifyDataErrorInfo, IModelBase
    {
        #region INotifyDataErrorInfo
        ErrorsContainer<string> _errorsContainer;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorsContainer.GetErrors(propertyName);
        }

        public void SetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression, IEnumerable<string> errors)
        {
            ErrorsContainer.SetErrors(propertyExpression, errors);
        }

        public virtual bool HasErrors
        {
            get { return ErrorsContainer.HasErrors; }
        }

        public Dictionary<string, List<string>> GetAllErrors()
        {
            return ErrorsContainer.GetAllErrors();
        }


        protected ErrorsContainer<string> ErrorsContainer
        {
            get
            {
                if (_errorsContainer == null)
                {
                    _errorsContainer =
                        new ErrorsContainer<string>(pn => this.RaiseErrorsChanged(pn));
                }

                return _errorsContainer;
            }
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged(this, e);
        }

        public bool ValidateProperty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var propertyInfo = this.GetType().GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            var propertyErrors = new List<string>();
            bool isValid = TryValidateProperty(propertyInfo, propertyErrors);
            ErrorsContainer.SetErrors(propertyInfo.Name, propertyErrors);

            return isValid;
        }

        public bool ValidateProperties()
        {
            var propertiesWithChangedErrors = new List<string>();

            // Get all the properties decorated with the ValidationAttribute attribute.
            var propertiesToValidate = this.GetType().GetRuntimeProperties().Where(c => c.GetCustomAttributes(typeof(ValidationAttribute)).Any());

            foreach (PropertyInfo propertyInfo in propertiesToValidate)
            {
                var propertyErrors = new List<string>();
                TryValidateProperty(propertyInfo, propertyErrors);

                // If the errors have changed, save the property name to notify the update at the end of this method.
                ErrorsContainer.SetErrors(propertyInfo.Name, propertyErrors);
            }

            return ErrorsContainer.HasErrors;
        }

        private bool TryValidateProperty(PropertyInfo propertyInfo, List<string> propertyErrors)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this) { MemberName = propertyInfo.Name };
            object propertyValue = propertyInfo.GetValue(this);

            // Validate the property
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (results.Any())
            {
                propertyErrors.AddRange(results.Select(c => c.ErrorMessage));
            }

            return isValid;
        }
        #endregion
    }
}