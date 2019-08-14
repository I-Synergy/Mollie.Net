using System.Collections.Generic;

namespace Mollie.Models.Order
{
    public class OrderLineCancellationRequest
    {
        public IEnumerable<OrderLineDetails> Lines { get; set; }
    }
}
