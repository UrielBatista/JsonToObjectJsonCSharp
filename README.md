# Json to CSharp

Convert jsonPayload to Object C#
- Take Payload to JsonData.json in /bin/...
- Execute console application and see console element
- Element returns in console with new data C# Object.
```json
{
  "legalFeeNet": 363.54,
  "name": "Will",
  "legalFeeVat": 72.708,
  "discountNet": 0.0,
  "discountVat": 0.0,
  "otherNet": 12.0,
  "otherVat": 2.4,
  "disbursementNet": 220.0,
  "disbursementVat": 0.0,
  "amlCheck": null,
  "legalSubTotal": 363.54,
  "totalFee": 450.648,
  "discounts": 0.0,
  "vat": 75.108,
  "discountedPrice": 360.5184,
  "recommendedRetailPrice": 450.648,
  "subTotal": 375.54,
  "isDiscounted": false,
  "customerCount": 3
}
```
- Element convert in new csharp object dynamic
```csharp
{
  LegalFeeNet = 363.54
  Name: "Will"
  LegalFeeVat = 72.708
  DiscountNet = 0.0
  DiscountVat = 0.0
  OtherNet = 12.0
  OtherVat = 2.4
  DisbursementNet = 220.0
  DisbursementVat = 0.0
  AmlCheck = null
  LegalSubTotal = 363.54
  TotalFee = 450.648
  Discounts = 0.0
  Vat = 75.108
  DiscountedPrice = 360.5184
  RecommendedRetailPrice = 450.648
  SubTotal = 375.54
  IsDiscounted = false
  CustomerCount = 3
}
```
