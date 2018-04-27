using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Refund;

namespace Mollie.Abstract {
    public interface IRefundClient {
        Task CancelRefundAsync(string paymentId, string refundId);
        Task<RefundResponse> CreateRefundAsync(string paymentId);
        Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest);
        Task<RefundResponse> GetRefundAsync(string paymentId, string refundId);
        Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, int? offset = default(int?), int? count = default(int?));
    }
}