# Nevermindjq.Payments.CryptoPay
================================

## Introduction
---------------

Nevermindjq.Payments.CryptoPay is a .NET client library for interacting with the CryptoPay API. CryptoPay is a payment system based on the CryptoBot, which allows you to accept payments in cryptocurrency using the API.

## Installation
---------------

To use the Nevermindjq.Payments.CryptoPay library, you can install it via NuGet:

```
Install-Package Nevermindjq.Payments.CryptoPay
```

## Usage
-----

### API

First, you need to create your a[Program.cs](Tests/Tests.Host/Program.cs)pplication and get an API token. Open [@CryptoBot](https://t.me/CryptoBot?start=pay)
or [@CryptoTestnetBot](https://t.me/CryptoTestnetBot?start=pay) (for testnet), send a command `/pay` to create a new app
and get API Token.

Don't forget to configure the `ApiUrl` and your `CryptoPayApiToken`:

#### Register services

```csharp
builder.Services.AddCryptoPay(builder.Configuration["Payments:CryptoPay:Token"]!, builder.Configuration["Payments:CryptoPay:Network"]);
```

#### Configure application 

```csharp
app.UseCryptoPay(); // Requires for validation CryptoPay webhook
```

#### Use

Next step: try to call a simple `GetMeAsync(...)` method to check that everything is working well:

```csharp
var application = await cryptoPayClient.GetMeAsync(cancellationToken);
```

| Net     | Bot                                                          | Hostname                         |
|---------|--------------------------------------------------------------|----------------------------------|
| mainnet | [@CryptoBot](https://t.me/CryptoBot?start=pay)               | `https://pay.crypt.bot/`         |
| testnet | [@CryptoTestnetBot](https://t.me/CryptoTestnetBot?start=pay) | `https://testnet-pay.crypt.bot/` |

> All queries to the Crypto Pay API must be sent over **HTTPS**

You can find all available methods in the [documentation](https://help.crypt.bot/crypto-pay-api).

Also, you can create invoice with supported [assets](#Assets) and [paid button names](#Paid-Button-Names):

```csharp
// Create an invoice for 0.1 TON with accepted assets "TON", "USDT", and "TRX", and a "openBot" paid button that redirects to "https://t.me/tests_nmjq_robot"
var invoice = await cryptoPayClient.CreateInvoiceAsync(
    amount: 0.1, // The amount of the asset for the invoice
    currencyType: CurrencyTypes.crypto, // The type of currency (e.g., crypto or fiat)
    asset: "TON", // The asset for the invoice (e.g., TON, USDT, TRX)
    acceptedAssets: ["TON", "USDT", "TRX"], // Optional: List of accepted assets for the invoice
    paidBtnName: PaidButtonNames.openBot, // Optional: Name of the button that will be shown to the user after the invoice is paid
    paidBtnUrl: "https://t.me/CryptoBot", // Optional: URL that will be opened when the button is pressed
    payload: "user_id" // Optional: Additional payload to be included with the invoice
);
```

#### Webhook

Here is an example of a controller endpoint that handles webhook updates. The `ValidationMiddleware` has already verified the signature and stored the `Update` object in the `HttpContext.Items` dictionary. You can retrieve it using the `GetUpdate` extension method provided by the library.

```csharp
[ApiController, Route("webhooks/crypto-pay")]
public class CryptoPayController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {
        var update = HttpContext.GetUpdate();
        
        // Process update here

        return Ok();
    }
}
```

### Configuration Example

Here is an example of how to configure the library in the `appsettings.json` file:

```json
{
  "Bot": {
    "Token": "Token"
  },
  "Payments": {
    "CryptoPay": {
      "Network": "Network",
      "Token": "ApiKey"
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## Security
------------

The CryptoPay API uses HTTPS to ensure that all requests are secure. When using webhooks, it is recommended to use a secret path in the URL to prevent unauthorized access.

## Conclusion
--------------

The Nevermindjq.Payments.CryptoPay library provides a convenient and secure way to interact with the CryptoPay API. By following the examples and guidelines in this documentation, you can easily integrate CryptoPay into your .NET application.

## Additional Resources
----------------------

* [CryptoPay API Documentation](https://help.crypt.bot/crypto-pay-api)
* [NuGet Package](https://www.nuget.org/packages/Nevermindjq.Payments.CryptoPay)