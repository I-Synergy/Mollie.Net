using Mollie.Enumerations;
using Mollie.Models.Payment.Response;

namespace Mollie.Factories
{
    public class PaymentResponseFactory
    {
        public PaymentResponse Create(PaymentMethods? paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethods.BankTransfer:
                    return new BankTransferPaymentResponse();
                case PaymentMethods.Bitcoin:
                    return new BitcoinPaymentResponse();
                case PaymentMethods.CreditCard:
                    return new CreditCardPaymentResponse();
                case PaymentMethods.Ideal:
                    return new IdealPaymentResponse();
                case PaymentMethods.MisterCash:
                    return new MisterCashPaymentResponse();
                case PaymentMethods.PayPal:
                    return new PayPalPaymentResponse();
                case PaymentMethods.PaySafeCard:
                    return new PaySafeCardPaymentResponse();
                case PaymentMethods.PodiumCadeaukaart:
                    return new PodiumCadeauKaartPaymentResponse();
                case PaymentMethods.Sofort:
                    return new SofortPaymentResponse();
                case PaymentMethods.Belfius:
                    return new BelfiusPaymentResponse();
                case PaymentMethods.DirectDebit:
                    return new SepaDirectDebitResponse();
                case PaymentMethods.Kbc:
                    return new KbcPaymentResponse();
                default:
                    return new PaymentResponse();
            }
        }
    }
}
