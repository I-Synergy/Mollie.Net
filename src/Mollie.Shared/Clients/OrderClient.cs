using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Order;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class OrderClient : ClientBase, IOrderClient
    {
        public OrderClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest) =>
            PostAsync<OrderResponse>("orders", orderRequest);

        public Task<OrderResponse> GetOrderAsync(string orderId) =>
            GetAsync<OrderResponse>($"orders/{orderId}");

        public Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest) =>
            PatchAsync<OrderResponse>($"orders/{orderId}", orderUpdateRequest);

        public Task<OrderResponse> UpdateOrderLinesAsync(string orderId, string orderLineId, OrderLineUpdateRequest orderLineUpdateRequest) =>
            PatchAsync<OrderResponse>($"orders/{orderId}/lines/{orderLineId}", orderLineUpdateRequest);

        public Task CancelOrderAsync(string orderId) =>
            DeleteAsync($"orders/{orderId}");

        public Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null) =>
            GetListAsync<ListResponse<OrderResponse>>($"orders", from, limit);

        public Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url) =>
            GetAsync(url);

        public Task CancelOrderLinesAsync(string orderId, OrderLineCancellationRequest cancelationRequest) =>
            DeleteAsync($"orders/{orderId}/lines", cancelationRequest);

        public Task<PaymentResponse> CreateOrderPaymentAsync(string orderId, OrderPaymentRequest createOrderPaymentRequest) =>
            PostAsync<PaymentResponse>($"orders/{orderId}/payments", createOrderPaymentRequest);

        public Task CreateOrderRefundAsync(string orderId, OrderRefundRequest createOrderRefundRequest) =>
            DeleteAsync($"orders/{orderId}/refunds", createOrderRefundRequest);

        public Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string orderId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"orders/{orderId}/refunds", from, limit);
    }
}