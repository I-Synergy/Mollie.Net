# Mollie .Net

First i want to thank [Vincent Kok](http://vincentkok.net) for his marvelous work.
I took the liberty to migrate this project to .net standard 2.0 which makes it usable for UWP, Xamarin and Asp.Net Core.
Again, many kudo's for Vincent.

This project allows you to easily add the [Mollie payment provider](https://www.mollie.com) to your application. Mollie has excellent [documentation](https://www.mollie.com/en/docs/overview) which I highly recommend you read before using this library. Please keep in mind that this is a 3rd party library and I am in no way associated with Mollie. 

If you have encounter any issues while using this library or have any feature requests, feel free to open an issue on GitHub. 

## Getting started

### Installing the library
The easiest way to install the Mollie .Net Standard library is to use the [Nuget Package](https://www.nuget.org/packages/Mollie.Net).
```
Install-Package Mollie.Net
```

### Example projects
An example web application project that allows you to view, create, pay and refund payments is included. In order to use this project you have to set your Mollie API key in the web.config file. 

### Supported frameworks
The library was recently converted from a .NET framework class library to a .NET standard 1.2 class library. This means that the library can now be used in .NET framework and .NET core applications. 

### Supported API's
This library currently supports the following API's:
- Payments API
- PaymentMethod
- Customers API
- Mandates API
- Subscriptions API
- Issuer API
- Refund API
- Connect API
- Chargebacks API
- Invoices API
- Permissions API
- Profiles API
- Organisations API

### Creating a API client object
Every API has it's own API client class. These are: PaymentClient, PaymentMethodClient, CustomerClient, MandateClient, SubscriptionClient, IssuerClient and RefundClient classes. 

These classes allow you to send and receive requests to the Mollie REST webservice. To create a API client class, you simple instantiate a new object for the API you require. For example, if you want to create new payments, you can use the PaymentClient class. 
```c#
PaymentClient paymentClient = new PaymentClient("{your_api_key}");
```
### Payments
#### Creating a payment
```c#
PaymentClient paymentClient = new PaymentClient("{your_api_key}");
PaymentRequest paymentRequest = new PaymentRequest() {
    Amount = 100,
    Description = "Test payment of the example project",
    RedirectUrl = "http://google.com"
};

PaymentResponse paymentResponse = paymentClient.CreatePaymentAsync(paymentRequest).Result;
```

If you want to create a payment with a specific paymentmethod, there are seperate classes that allow you to set paymentmethod specific parameters. For example, a bank transfer payment allows you to set the billing e-mail and due date. Have a look at the [Mollie create payment documentation](https://www.mollie.com/nl/docs/reference/payments/create) for more information. 

The full list of payment specific request classes is:
- BankTransferPaymentRequest
- CreditCardPaymentRequest
- IDealPaymentRequest
- PayPalPaymentRequest
- SepaDirectDebitRequest
- KbcPaymentRequest

#### Retrieving a payment by id
```c#
PaymentClient paymentClient = new PaymentClient("{your_api_key}");
PaymentResponse result = paymentClient.GetPaymentAsync(paymentResponse.Id).Result;
```

Keep in mind that some payment methods have specific payment detail values. For example: PayPal payments have reference and customer reference properties. In order to access these properties you have to cast the PaymentResponse to the PayPalPaymentResponse and access the Detail property. 

Take a look at the [Mollie payment response documentation](https://www.mollie.com/en/docs/reference/payments/get) for a full list of payment methods that have extra detail fields.

The full list of payment specific response classes is:
- BankTransferPaymentResponse
- BelfiusPaymentResponse
- BitcoinPaymentResponse
- CreditCardPaymentResponse
- IdealPaymentResponse
- KbcPaymentResponse
- MisterCashPaymentResponse
- PayPalPaymentResponse
- PaySafeCardPaymentResponse
- PodiumCadeauKaartPaymentResponse
- SepaDirectDebitResponse
- SofortPaymentResponse

#### Setting metadata
Mollie allows you to send any metadata you like in JSON notation and will save the data alongside the payment. When you fetch the payment with the API, Mollie will include the metadata. The library allows you to set the metadata JSON string manually, by setting the Metadata property of the PaymentRequest class, but the recommended way of setting/getting the metadata is to use the SetMetadata/Getmetadata methods. 

For example: 
```c#
// Custom metadata class that contains the data you want to include in the metadata class. 
CustomMetadataClass metadataRequest = new CustomMetadataClass() {
    OrderId = 1,
    Description = "Custom description"
};

// Create a new payment
PaymentRequest paymentRequest = new PaymentRequest() {
    Amount = 100,
    Description = "Description",
    RedirectUrl = this.DefaultRedirectUrl,
};

// Set the metadata
paymentRequest.SetMetadata(metadataRequest);

// When we retrieve the payment response, we can convert our metadata back to our custom class
PaymentResponse result = await this._paymentClient.CreatePaymentAsync(paymentRequest);
CustomMetadataClass metadataResponse = result.GetMetadata<CustomMetadataClass>();
```

#### Retrieving a list off payments
Mollie allows you to set offset and count properties so you can paginate the list. The offset and count parameters are optional. The maximum number of payments you can request in a single roundtrip is 250. 
```c#
PaymentClient paymentClient = new PaymentClient("{your_api_key}");
ListResponse<PaymentResponse> response = paymentClient.GetPaymentListAsync(offset, count).Result;
```

### Payment methods
#### Retrieving a list of all payment methods
Mollie allows you to set offset and count properties so you can paginate the list. The offset and count parameters are optional.
```c#
PaymentMethodClient _paymentMethodClient = new PaymentMethodClient("{your_api_key}");
ListResponse<PaymentMethodResponse> paymentMethodList = paymentMethodClient.GetPaymentMethodListAsync(offset, count).Result;
foreach (PaymentMethodResponse paymentMethod in paymentMethodList.Data) {
  // Your code here
}
```
#### Retrieving a single payment method
```c#
PaymentMethodClient _paymentMethodClient = new PaymentMethodClient("{your_api_key}");
PaymentMethodResponse paymentMethodResponse = paymentMethodClient.GetPaymentMethodAsync(paymentMethod).Result;
```

### Issuer methods
#### Retrieve issuer list
```c#
IssuerClient issuerClient = new IssuerClient("{your_api_key}");
ListResponse<IssuerResponse> issuerList = this.issuerClient.GetIssuerListAsync().Result;
foreach (IssuerResponse issuer in issuerList.Data) {
    // Your code here
}
```

#### Retrieve a single issuer by id
```c#
IssuerClient issuerClient = new IssuerClient("{your_api_key}");
issuerClient.GetIssuerAsync(issuerId).Result;
```

### Refund methods
#### Create a new refund
```c#
RefundClient refundClient = new RefundClient("{your_api_key}");
RefundResponse refundResponse = refundClient.CreateRefund(payment.Id).Result;
```

#### Create a partial refund
```c#
RefundClient refundClient = new RefundClient("{your_api_key}");
RefundRequest refundRequest = new RefundRequest() {
    Amount = 50
};
RefundResponse refundResponse = this.refundClient.CreateRefund(payment.Id, refundRequest).Result;
```

#### Retrieve a refund by payment and refund id
```c#
RefundClient refundClient = new RefundClient("{your_api_key}");
RefundResponse refundResponse = refundClient.GetRefund(payment.Id, refundResponse.Id).Result;
```

#### Retrieve refund list
Mollie allows you to set offset and count properties so you can paginate the list. The offset and count parameters are optional.
```c#
RefundClient refundClient = new RefundClient("{your_api_key}");
ListResponse<RefundResponse> refundList = refundClient.GetRefundList(payment.Id, offset, count).Result;
```

#### Cancel a refund
```c#
RefundClient refundClient = new RefundClient("{your_api_key}");
refundClient.CancelRefund(paymentId, refundId);
```
