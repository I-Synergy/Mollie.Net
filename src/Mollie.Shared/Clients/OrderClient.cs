using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Order;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class OrderClient : ClientBase, IOrderClient
    {
        public OrderClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest) =>
            ClientService.PostAsync<OrderResponse>("orders", orderRequest);

        public Task<OrderResponse> GetOrderAsync(string orderId) =>
            ClientService.GetAsync<OrderResponse>($"orders/{orderId}");

        public Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest) =>
            ClientService.PatchAsync<OrderResponse>($"orders/{orderId}", orderUpdateRequest);

        public Task<OrderResponse> UpdateOrderLinesAsync(string orderId, string orderLineId, OrderLineUpdateRequest orderLineUpdateRequest) =>
            ClientService.PatchAsync<OrderResponse>($"orders/{orderId}/lines/{orderLineId}", orderLineUpdateRequest);

        public Task CancelOrderAsync(string orderId) =>
            ClientService.DeleteAsync($"orders/{orderId}");

        public Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<OrderResponse>>($"orders", from, limit);

        public Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url) =>
            ClientService.GetAsync(url);

        public Task CancelOrderLinesAsync(string orderId, OrderLineCancellationRequest cancelationRequest) =>
            ClientService.DeleteAsync($"orders/{orderId}/lines", cancelationRequest);

        public Task<PaymentResponse> CreateOrderPaymentAsync(string orderId, OrderPaymentRequest createOrderPaymentRequest) =>
            ClientService.PostAsync<PaymentResponse>($"orders/{orderId}/payments", createOrderPaymentRequest);

        public Task CreateOrderRefundAsync(string orderId, OrderRefundRequest createOrderRefundRequest) =>
            ClientService.DeleteAsync($"orders/{orderId}/refunds", createOrderRefundRequest);

        public Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string orderId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<RefundResponse>>($"orders/{orderId}/refunds", from, limit);
    }
}