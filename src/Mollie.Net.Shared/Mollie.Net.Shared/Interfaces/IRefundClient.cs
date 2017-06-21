using Mollie.Net.Models.List;
using Mollie.Net.Models.Refund;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface IRefundClient
    {
        Task CancelRefundAsync(string paymentId, string refundId);
        Task<RefundResponse> CreateRefundAsync(string paymentId);
        Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest);
        Task<RefundResponse> GetRefundAsync(string paymentId, string refundId);
        Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, int? offset = default(int?), int? count = default(int?));
    }
}
