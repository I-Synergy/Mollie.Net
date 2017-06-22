using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Response;
using Mollie.Net.Models.Payment.Responses;
using Mollie.Net.Models.Payment.Responses.Specific;

namespace Mollie.Net.Factories
{
    public class PaymentResponseFactory
    {
        public PaymentResponse Create(PaymentMethod? paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.BankTransfer:
                    return new BankTransferPaymentResponse();
                case PaymentMethod.Bitcoin:
                    return new BitcoinPaymentResponse();
                case PaymentMethod.CreditCard:
                    return new CreditCardPaymentResponse();
                case PaymentMethod.Ideal:
                    return new IdealPaymentResponse();
                case PaymentMethod.MisterCash:
                    return new MisterCashPaymentResponse();
                case PaymentMethod.PayPal:
                    return new PayPalPaymentResponse();
                case PaymentMethod.PaySafeCard:
                    return new PaySafeCardPaymentResponse();
                case PaymentMethod.PodiumCadeaukaart:
                    return new PodiumCadeauKaartPaymentResponse();
                case PaymentMethod.Sofort:
                    return new SofortPaymentResponse();
                case PaymentMethod.Belfius:
                    return new BelfiusPaymentResponse();
                case PaymentMethod.DirectDebit:
                    return new SepaDirectDebitResponse();
                case PaymentMethod.Kbc:
                    return new KbcPaymentResponse();
                default:
                    return new PaymentResponse();
            }
        }
    }
}
