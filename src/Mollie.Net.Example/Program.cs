using Mollie.Net.Clients;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Payment.Method;
using Mollie.Net.Models.Payment.Request;
using Mollie.Net.Models.Payment.Response;
using System;
using System.Threading.Tasks;

namespace Mollie.Net.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "{your_api_test_key}";
            PaymentClient paymentClient = new PaymentClient(apiKey);
            PaymentMethodClient paymentMethodClient = new PaymentMethodClient(apiKey);

            OutputAndWait("Press any key to create a new payment");
            OutputNewPaymentAsync(paymentClient).ConfigureAwait(false);
            OutputAndWait("Press any key to retrieve a list of payments");
            OutputPaymentListAsync(paymentClient);
            OutputAndWait("Press any key to retrieve a list of payment methods");
            OutputPaymentMethods(paymentMethodClient);
            OutputAndWait("Example completed");
        }

        static async Task OutputNewPaymentAsync(PaymentClient paymentClient)
        {
            Console.WriteLine("Creating a payment");
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Test payment of the example project",
                RedirectUrl = "http://google.com"
            };

            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
            Console.WriteLine("Payment created");
            Console.WriteLine("");
            Console.WriteLine($"Payment can be paid on the following URL: {paymentResponse.Links.PaymentUrl}");
        }

        static async Task OutputPaymentListAsync(PaymentClient paymentClient)
        {
            Console.WriteLine("Outputting the first 2 payments");
            ListResponse<PaymentResponse> paymentList = await paymentClient.GetPaymentListAsync(0, 2);
            foreach (PaymentResponse paymentResponse in paymentList.Data)
            {
                Console.WriteLine($"Payment Id: { paymentResponse.Id } - Payment method: { paymentResponse.Method }");
            }
        }

        static void OutputPaymentMethods(PaymentMethodClient paymentMethodClient)
        {
            Console.WriteLine("Ouputting all payment methods");
            ListResponse<PaymentMethodResponse> paymentMethodList = paymentMethodClient.GetPaymentMethodListAsync(0, 100).Result;
            foreach (PaymentMethodResponse paymentMethodResponse in paymentMethodList.Data)
            {
                Console.WriteLine($"Payment method description: { paymentMethodResponse.Description }");
            }
        }

        static void OutputAndWait(string output)
        {
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
