![.NET Core CI](https://github.com/Norsk-Global/BookingApi-Sdk-CSharp/workflows/.NET%20Core%20CI/badge.svg)

# Norsk Global Booking API
<p class="align">
    <img src="https://norsk.global/wp-content/uploads/2016/11/norsk-logo-1.png" alt="Norsk Logo" width="600px">
</p>

### Description
This SDK will help you to incorporate Norsk Globals Extensive Booking Api ([Norsk Booking Api](http://api.norsk-global.com/help/schema)) into every day applications, business processes, and workflows. Use one of our many SDKs to get started quickly and easily integrate API calls into your applications.

### Norsk Global Booking APIs:

* [Retrieve Scanned Image](http://api.norsk-global.com/help/schema/GET-api-package-barcode-scanimage) : Retrieved captured image of your shipment present.

* [Retrieve Shipment Dimensions](http://api.norsk-global.com/help/schema/GET-api-bulk-shipment-dimensions) : Retrieve captured weight/dimensions for multiple shipments.

* [Retrieve Item Dimensions](http://api.norsk-global.com/help/schema/GET-api-shipment-barcode-dimensions) : Retrieve captured weight/dimensions for a shipment items.

* [Track Shipment](http://api.norsk-global.com/help/schema/GET-api-shipment-barcode) : Retrieve shipment tracking information.

* [Book Shipment](http://api.norsk-global.com/help/schema/POST-api-shipment) : Book a shipment.

* [Retrieve Shipment Label](http://api.norsk-global.com/help/schema/GET-api-shipment-barcode-label) : Generate a label for a booked shipment.

### Book Shipment

A simple Booking Request with no value can be as follows:

``` C#

// Book a shipment using the FluentFactories provided.
// All Authentication and requests are handled in the background.
var response = ApiClient
                .BookShipment(booking => booking
                    .CreateBooking()
                    .WithReadyByDate()
                    .WithHawb("123123123")
                    .WithDescription("test Clothing")
                    .WithDocuments()
                    .WithPieces(pieces => pieces
                        .AddPiece(piece => piece
                            .Depth(1.00m)
                            .Height(1.00m)
                            .Width(1.00m)
                            .Weight(1.00m)
                            .NumberOfPieces(1)))
                    .WithConsignee(consignee => consignee
                        .ContactName("Test")
                        .Company("Test")
                        .Address1("2 Willow Road")
                        .Zipcode("SL3 0BS")
                        .City("Slough")
                        .CountryCode("GB"))
                    .WithServiceCode("IEL")
                );
                
// Retrieve Information from response if 200.
var trackingNumber = response.Barcode;
var label = response.RawLabel();
```
