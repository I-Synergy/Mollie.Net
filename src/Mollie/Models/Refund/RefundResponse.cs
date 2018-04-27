using Mollie.Enumerations;
using Mollie.Models.Payment.Response;
using System;

namespace Mollie.Models.Refund
{
    public class RefundResponse
    {
        public string Id { get; set; }
        public PaymentResponse Payment { get; set; }
        public DateTime? RefundedDatetime { get; set; }
        public decimal Amount { get; set; }
        public RefundStatus Status { get; set; }

        public override string ToString() => $"Id: {this.Id} - PaymentId: {this.Payment.Id}";
    }
}
