using Mollie.Net.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Net.Models.List
{
    public class ListResponse<T> : ListResponseSimple<T>
    {
        /// <summary>
        /// Gets or sets the Offset property value.
        /// </summary>
        public int Offset
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the TotalCount property value.
        /// </summary>
        public int TotalCount
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Links property value.
        /// </summary>
        public ListResponseLinks Links
        {
            get { return GetValue<ListResponseLinks>(); }
            set { SetValue(value); }
        }
    }

    public class ListResponseSimple<T> : ModelBase
    {
        /// <summary>
        /// Gets or sets the Count property value.
        /// </summary>
        public int Count
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Data property value.
        /// </summary>
        public List<T> Data
        {
            get { return GetValue<List<T>>(); }
            set { SetValue(value); }
        }
    }
}
