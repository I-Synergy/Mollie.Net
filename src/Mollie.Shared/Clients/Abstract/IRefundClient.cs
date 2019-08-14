using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface IRefundClient
    {
        Task CancelRefundAsync(string paymentId, string refundId);
        Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest);
        Task<RefundResponse> GetRefundAsync(string paymentId, string refundId);
        Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, string from = null, int? limit = null);
        Task<RefundResponse> GetRefundAsync(UrlObjectLink<RefundResponse> url);
    }
}