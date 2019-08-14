using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Enumerations;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.Order;
using Mollie.Models.Payment;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class OrderTests : BaseApiTestFixture
    {
        [TestMethod]
        public async Task CanCreateOrderWithOnlyRequiredFields() {
            // If: we create a order request with only the required parameters
            OrderRequest orderRequest = this.CreateOrderRequestWithOnlyRequiredFields();

            // When: We send the order request to Mollie
            OrderResponse result = await OrderClient.CreateOrderAsync(orderRequest);

            // Then: Make sure we get a valid response
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.Amount.Value, result.Amount.Value);
            Assert.AreEqual(orderRequest.Amount.Currency, result.Amount.Currency);
            Assert.AreEqual(orderRequest.OrderNumber, result.OrderNumber);
        }

        [TestMethod]
        public async Task CanRetrieveOrderAfterCreationOrder() {
            // If: we create a new order
            OrderRequest orderRequest = this.CreateOrderRequestWithOnlyRequiredFields();
            OrderResponse createdOrder = await OrderClient.CreateOrderAsync(orderRequest);

            // When: We attempt to retrieve the order
            OrderResponse retrievedOrder = await OrderClient.GetOrderAsync(createdOrder.Id);

            // Then: Make sure we get a valid response
            Assert.IsNotNull(retrievedOrder);
            Assert.AreEqual(createdOrder.Id, retrievedOrder.Id);
        }

        [TestMethod]
        public async Task CanUpdateExistingOrder() {
            // If: we create a new order
            OrderRequest orderRequest = this.CreateOrderRequestWithOnlyRequiredFields();
            OrderResponse createdOrder = await OrderClient.CreateOrderAsync(orderRequest);

            // When: We attempt to update the order
            OrderUpdateRequest orderUpdateRequest = new OrderUpdateRequest() {
                OrderNumber = "1337",
                BillingAddress = createdOrder.BillingAddress
            };
            orderUpdateRequest.BillingAddress.City = "Den Haag";
            OrderResponse updatedOrder = await OrderClient.UpdateOrderAsync(createdOrder.Id, orderUpdateRequest);

            // Then: Make sure the order is updated
            Assert.AreEqual(orderUpdateRequest.OrderNumber, updatedOrder.OrderNumber);
            Assert.AreEqual(orderUpdateRequest.BillingAddress.City, updatedOrder.BillingAddress.City);
        }

        [TestMethod]
        public async Task CanCancelCreatedOrder() {
            // If: we create a new order
            OrderRequest orderRequest = this.CreateOrderRequestWithOnlyRequiredFields();
            OrderResponse createdOrder = await OrderClient.CreateOrderAsync(orderRequest);

            // When: We attempt to cancel the order and then retrieve it
            await OrderClient.CancelOrderAsync(createdOrder.Id);
            OrderResponse canceledOrder = await OrderClient.GetOrderAsync(createdOrder.Id);

            // Then: The order status should be cancelled
            Assert.AreEqual(OrderStatus.Canceled, canceledOrder.Status);
        }

        [TestMethod]
        public async Task CanUpdateOrderLine() {
            // If: we create a new order
            OrderRequest orderRequest = this.CreateOrderRequestWithOnlyRequiredFields();
            OrderResponse createdOrder = await OrderClient.CreateOrderAsync(orderRequest);

            // When: We update the order line
            OrderLineUpdateRequest updateRequest = new OrderLineUpdateRequest() {
                Name = "A fluffy bear"
            };
            OrderResponse updatedOrder = await OrderClient.UpdateOrderLinesAsync(createdOrder.Id, createdOrder.Lines.First().Id, updateRequest);

            // Then: The name of the order line should be updated
            Assert.AreEqual(updateRequest.Name, updatedOrder.Lines.First().Name);
        }

        [TestMethod]
        public async Task CanRetrieveOrderList() {
            // When: Retrieve payment list with default settings
            ListResponse<OrderResponse> response = await OrderClient.GetOrderListAsync();

            // Then
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Items);
        }

        [TestMethod]
        public async Task ListOrdersNeverReturnsMorePaymentsThenTheNumberOfRequestedOrders() {
            // If: Number of orders requested is 5
            int numberOfOrders = 5;

            // When: Retrieve 5 orders
            ListResponse<OrderResponse> response = await OrderClient.GetOrderListAsync(null, numberOfOrders);

            // Then
            Assert.IsTrue(response.Items.Count <= numberOfOrders);
        }

        private OrderRequest CreateOrderRequestWithOnlyRequiredFields() {
            return new OrderRequest() {
                Amount = new Amount(Currency.EUR, "100.00"),
                OrderNumber = "16738",
                Lines = new List<OrderLineRequest>() {
                    new OrderLineRequest() {
                        Name = "A box of chocolates",
                        Quantity = 1,
                        UnitPrice = new Amount(Currency.EUR, "100.00"),
                        TotalAmount = new Amount(Currency.EUR, "100.00"),
                        VatRate = "21.00",
                        VatAmount = new Amount(Currency.EUR, "17.36")
                    }
                },
                BillingAddress = new OrderAddressDetails() {
                    GivenName = "John",
                    FamilyName = "Smit",
                    Email = "johnsmit@gmail.com",
                    City = "Rotterdam",
                    Country = "NL",
                    PostalCode = "0000AA",
                    Region = "Zuid-Holland",
                    StreetAndNumber = "Coolsingel 1"
                },
                RedirectUrl = "http://www.google.nl",
                Locale = Locale.nl_NL
            };
        }
    }
}