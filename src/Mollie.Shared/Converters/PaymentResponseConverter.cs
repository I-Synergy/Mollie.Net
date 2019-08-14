using Mollie.Enumerations;
using Mollie.Framework.Factories;
using Mollie.Models.Payment.Response;
using Newtonsoft.Json.Linq;
using System;

namespace Mollie.Converters
{
    public class PaymentResponseConverter : JsonCreationConverter<PaymentResponse>
    {
        private readonly PaymentResponseFactory _paymentResponseFactory;

        public PaymentResponseConverter(PaymentResponseFactory paymentResponseFactory)
        {
            _paymentResponseFactory = paymentResponseFactory;
        }

        protected override PaymentResponse Create(Type objectType, JObject jObject)
        {
            var paymentMethod = GetPaymentMethod(jObject);

            return _paymentResponseFactory.Create(paymentMethod);
        }

        private PaymentMethods? GetPaymentMethod(JObject jObject)
        {
            if (FieldExists("method", jObject))
            {
                var paymentMethodValue = (string)jObject["method"];
                if (!string.IsNullOrEmpty(paymentMethodValue))
                {
                    return (PaymentMethods)Enum.Parse(typeof(PaymentMethods), paymentMethodValue, true);
                }
            }

            return null;
        }
    }
}
