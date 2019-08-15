using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Order;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public interface IOrderClient
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest);
        Task<OrderResponse> GetOrderAsync(string orderId);
        Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest);
        Task<OrderResponse> UpdateOrderLinesAsync(string orderId, string orderLineId, OrderLineUpdateRequest orderLineUpdateRequest);
        Task CancelOrderAsync(string orderId);
        Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null);
        Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url);
        Task CancelOrderLinesAsync(string orderId, OrderLineCancellationRequest cancelationRequest);
        Task<PaymentResponse> CreateOrderPaymentAsync(string orderId, OrderPaymentRequest createOrderPaymentRequest);
        Task CreateOrderRefundAsync(string orderId, OrderRefundRequest createOrderRefundRequest);
        Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string orderId, string from = null, int? limit = null);
    }
}