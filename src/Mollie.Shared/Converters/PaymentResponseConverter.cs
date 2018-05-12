using Mollie.Enumerations;
using Mollie.Factories;
using Mollie.Models.Payment.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Converters
{
    public class PaymentResponseConverter : JsonCreationConverter<PaymentResponse>
    {
        private readonly PaymentResponseFactory _paymentResponseFactory;

        public PaymentResponseConverter(PaymentResponseFactory paymentResponseFactory)
        {
            this._paymentResponseFactory = paymentResponseFactory;
        }

        protected override PaymentResponse Create(Type objectType, JObject jObject)
        {
            var paymentMethod = this.GetPaymentMethod(jObject);

            return this._paymentResponseFactory.Create(paymentMethod);
        }

        private PaymentMethods? GetPaymentMethod(JObject jObject)
        {
            if (this.FieldExists("method", jObject))
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
