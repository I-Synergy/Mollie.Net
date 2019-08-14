using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.PaymentMethod;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Models.Profile.Response {
    public class ProfileResponseLinks {
        public UrlObjectLink<ProfileResponse> Self { get; set; }
        public UrlObjectLink<ListResponse<ChargebackResponse>> Chargebacks { get; set; }
        public UrlObjectLink<ListResponse<PaymentResponse>> Methods { get; set; }
        public UrlObjectLink<ListResponse<PaymentMethodResponse>> Payments { get; set; }
        public UrlObjectLink<ListResponse<RefundResponse>> Refunds { get; set; }
        public UrlLink CheckoutPreviewUrl { get; set; }
        public UrlLink Documentation { get; set; }
    }
}