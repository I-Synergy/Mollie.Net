using Mollie.Net.Models.Base;

namespace Mollie.Net.Models.List
{
    /// <summary>
    /// Links to help navigate through the lists of objects, based on the given offset.
    /// </summary>
    public class ListResponseLinks : ModelBase
    {
        /// <summary>
        /// Gets or sets the Previous property value.
        /// </summary>
        public string Previous
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Next property value.
        /// </summary>
        public string Next
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the First property value.
        /// </summary>
        public string First
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Last property value.
        /// </summary>
        public string Last
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
