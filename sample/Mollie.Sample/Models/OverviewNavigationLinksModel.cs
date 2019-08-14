using Mollie.Models.Url;

namespace Mollie.Sample.Models {
    public class OverviewNavigationLinksModel {
        public UrlLink Previous { get; set; }
        public UrlLink Next { get; set; }

        public OverviewNavigationLinksModel(UrlLink previous, UrlLink next) {
            this.Previous = previous;
            this.Next = next;
        }
    }
}