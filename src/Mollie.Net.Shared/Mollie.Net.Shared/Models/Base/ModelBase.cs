using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mollie.Net.Models.Base
{
    public abstract partial class ModelBase : INotifyPropertyChanged
    {
        #region Backing Dictionary

        private readonly Dictionary<string, object> _propertyBackingDictionary = new Dictionary<string, object>();

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;

            if (_propertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }

            return default(T);
        }

        protected bool SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            if (EqualityComparer<T>.Default.Equals(newValue, GetValue<T>(propertyName))) return false;

            _propertyBackingDictionary[propertyName] = newValue;

            OnPropertyChanged(propertyName);

            if (!string.IsNullOrEmpty(propertyName))
            {
                ValidateProperty(propertyName);
            }

            return true;
        }
        #endregion Backing Dictionary

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged
    }
}
