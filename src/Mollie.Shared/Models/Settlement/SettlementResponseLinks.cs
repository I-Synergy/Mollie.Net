using Mollie.Models.Chargeback;
using Mollie.Models.List;

using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Models.Settlement
{
    public class SettlementResponseLinks
    {
        /// <summary>
        /// The API resource URL of the settlement itself.
        /// </summary>
        public UrlObjectLink<SettlementResponse> Self { get; set; }

        /// <summary>
        /// The API resource URL of the payments that are included in this settlement.
        /// </summary>
        public UrlObjectLink<ListResponse<PaymentResponse>> Payments { get; set; }

        /// <summary>
        /// The API resource URL of the refunds that are included in this settlement.
        /// </summary>
        public UrlObjectLink<ListResponse<RefundResponse>> Refunds { get; set; }

        /// <summary>
        /// The API resource URL of the chargebacks that are included in this settlement.
        /// </summary>
        public UrlObjectLink<ListResponse<ChargebackResponse>> Chargebacks { get; set; }

        /// <summary>
        /// The URL to the settlement retrieval endpoint documentation.
        /// </summary>
        public UrlLink Documentation { get; set; }
    }
}