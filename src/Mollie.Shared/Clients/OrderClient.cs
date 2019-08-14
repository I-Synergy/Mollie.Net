using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest)
        {
            return await PostAsync<OrderResponse>("orders", orderRequest).ConfigureAwait(false);
        }

        public async Task<OrderResponse> GetOrderAsync(string orderId)
        {
            return await GetAsync<OrderResponse>($"orders/{orderId}").ConfigureAwait(false); ;
        }

        public async Task<OrderResponse> UpdateOrderAsync(string orderId, OrderUpdateRequest orderUpdateRequest)
        {
            return await PatchAsync<OrderResponse>($"orders/{orderId}", orderUpdateRequest).ConfigureAwait(false);
        }

        public async Task<OrderResponse> UpdateOrderLinesAsync(string orderId, string orderLineId, OrderLineUpdateRequest orderLineUpdateRequest)
        {
            return await PatchAsync<OrderResponse>($"orders/{orderId}/lines/{orderLineId}", orderLineUpdateRequest).ConfigureAwait(false);
        }

        public async Task CancelOrderAsync(string orderId)
        {
            await DeleteAsync($"orders/{orderId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<OrderResponse>> GetOrderListAsync(string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<OrderResponse>>($"orders", from, limit).ConfigureAwait(false);
        }

        public async Task<ListResponse<OrderResponse>> GetOrderListAsync(UrlObjectLink<ListResponse<OrderResponse>> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task CancelOrderLinesAsync(string orderId, OrderLineCancellationRequest cancelationRequest)
        {
            await DeleteAsync($"orders/{orderId}/lines", cancelationRequest).ConfigureAwait(false);
        }

        public async Task<PaymentResponse> CreateOrderPaymentAsync(string orderId, OrderPaymentRequest createOrderPaymentRequest)
        {
            return await PostAsync<PaymentResponse>($"orders/{orderId}/payments", createOrderPaymentRequest).ConfigureAwait(false);
        }

        public async Task CreateOrderRefundAsync(string orderId, OrderRefundRequest createOrderRefundRequest)
        {
            await DeleteAsync($"orders/{orderId}/refunds", createOrderRefundRequest);
        }

        public async Task<ListResponse<RefundResponse>> GetOrderRefundListAsync(string orderId, string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<RefundResponse>>($"orders/{orderId}/refunds", from, limit).ConfigureAwait(false);
        }
    }
}