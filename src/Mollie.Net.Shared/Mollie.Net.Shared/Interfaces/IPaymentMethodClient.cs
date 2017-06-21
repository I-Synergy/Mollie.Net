using Mollie.Net.Enumerations;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Payment.Method;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface IPaymentMethodClient
    {
        Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethod paymentMethod);
        Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(int? offset = default(int?), int? count = default(int?));
    }
}
