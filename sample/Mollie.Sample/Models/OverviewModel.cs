using System.Collections.Generic;
using Mollie.Models;

namespace Mollie.Sample.Models {
    public class OverviewModel<T> where T : IResponseObject {
        public List<T> Items { get; set; }
        public OverviewNavigationLinksModel Navigation { get; set; }
    }
}