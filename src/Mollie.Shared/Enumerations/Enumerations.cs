using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Mollie.Enumerations
{
    public enum CategoryCode
    {
        GeneralMerchandise = 5399,
        ElectronicsComputersAndSoftware = 5732,
        TravelRentalAndTransportation = 4121,
        FinancialServices = 6012,
        FoodAndDrinks = 5499,
        EventsFestivalsAndRecreation = 7999,
        BooksMagazinesAndNewspapers = 5192,
        PersonalServices = 7299,
        CharityAndDonations = 8398,
        Other = 0
    }

    public enum KbcIssuer
    {
        [EnumMember(Value = "kbc")]
        Kbc,
        [EnumMember(Value = "cbc")]
        Cbc
    }

    public enum MandateStatus
    {
        [EnumMember(Value = "valid")]
        Valid,
        [EnumMember(Value = "invalid")]
        Invalid,
        [EnumMember(Value = "pending")]
        Pending
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Mode
    {
        [EnumMember(Value = "live")]
        Live,
        [EnumMember(Value = "test")]
        Test
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethods
    {
        [EnumMember(Value = "bancontact")] Bancontact,
        [EnumMember(Value = "banktransfer")] BankTransfer,
        [EnumMember(Value = "belfius")] Belfius,
        [EnumMember(Value = "bitcoin")] Bitcoin,
        [EnumMember(Value = "creditcard")] CreditCard,
        [EnumMember(Value = "directdebit")] DirectDebit,
        [EnumMember(Value = "eps")] Eps,
        [EnumMember(Value = "giftcard")] GiftCard,
        [EnumMember(Value = "giropay")] Giropay,
        [EnumMember(Value = "ideal")] Ideal,
        [EnumMember(Value = "inghomepay")] IngHomePay,
        [EnumMember(Value = "kbc")] Kbc,
        [EnumMember(Value = "paypal")] PayPal,
        [EnumMember(Value = "paysafecard")] PaySafeCard,
        [EnumMember(Value = "sofort")] Sofort,
        [EnumMember(Value = "refund")] Refund,
        [EnumMember(Value = "klarnapaylater")] KlarnaPayLater,
        [EnumMember(Value = "klarnasliceit")] KlarnaSliceIt,
        [EnumMember(Value = "przelewy24")] Przelewy24,
        [EnumMember(Value = "applepay")] ApplePay,
    }

    /// <summary>
    /// The mode used to create this payment. Mode determines whether a payment is real or a test payment.
    /// </summary>
    public enum PaymentMode
    {
        [EnumMember(Value = "live")]
        Live,
        [EnumMember(Value = "test")]
        Test
    }

    public enum PaymentStatus
    {
        Open,
        Canceled,
        Pending,
        Authorized,
        Expired,
        Failed,
        Paid
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProfileStatus
    {
        [EnumMember(Value = "unverified")]
        Unverified,
        [EnumMember(Value = "verified")]
        Verified,
        [EnumMember(Value = "blocked")]
        Blocked
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecurringType
    {
        [EnumMember(Value = "first")]
        First,
        [EnumMember(Value = "recurring")]
        Recurring
    }

    public enum RefundStatus
    {
        Pending,
        Processing,
        Refunded,
        Queued,
        Failed
    }

    public enum ReviewStatus
    {
        /// <summary>
        ///  The changes are pending review. We will review your changes soon.
        /// </summary>
        Pending,
        /// <summary>
        /// We've reviewed and rejected your changes.
        /// </summary>
        Rejected
    }

    public enum SubscriptionStatus
    {
        Pending,
        Active,
        Canceled,
        Suspended,
        Completed
    }

    public enum InvoiceStatus
    {
        Open,
        Paid,
        Overdue
    }

    public enum SettlementStatus
    {
        Open,
        Pending,
        PaidOut,
        Failed
    }

    public enum CreditCardAudience
    {
        Consumer,
        Business
    }

    /// <summary>
    /// Only available if the payment has been completed – The type of security used during payment processing.
    /// </summary>
    public enum CreditCardSecurity
    {
        Normal,
        [EnumMember(Value = "3dsecure")]
        Secure3D
    }

    /// <summary>
    /// Only available if the payment has been completed – The fee region for the payment: intra-eu for consumer cards from the EU, and 
    /// other for all other cards.
    /// </summary>
    public enum CreditCardFeeRegion
    {
        [EnumMember(Value = "intra-eu")] IntraEu,
        [EnumMember(Value = "other")] Other,
        [EnumMember(Value = "american-express")] AmericanExpress,
        [EnumMember(Value = "carte-bancaire")] CarteBancaire,
        [EnumMember(Value = "maestro")] Maestro,
    }

    /// <summary>
    /// Only available for failed payments. Contains a failure reason code.
    /// </summary>
    public enum CreditCardFailureReason
    {
        [EnumMember(Value = "invalid_card_number")] InvalidCardNumber,
        [EnumMember(Value = "invalid_cvv")] InvalidCvv,
        [EnumMember(Value = "invalid_card_holder_name")] InvalidCardHolderName,
        [EnumMember(Value = "card_expired")] CardExpired,
        [EnumMember(Value = "invalid_card_type")] InvalidCardType,
        [EnumMember(Value = "refused_by_issuer")] RefusedByIssuer,
        [EnumMember(Value = "insufficient_funds")] InsufficientFunds,
        [EnumMember(Value = "inactive_card")] InactiveCard,
        [EnumMember(Value = "unknown_reason")] UnknownReason,
        [EnumMember(Value = "possible_fraud")] PossibleFraud
    }

    /// <summary>
    /// The card's label. Note that not all labels can be acquired through Mollie.
    /// </summary>
    public enum CreditCardLabel
    {
        [EnumMember(Value = "American Express")] AmericanExpress,
        [EnumMember(Value = "Carta si")] CartaSi,
        [EnumMember(Value = "Carte Bleue")] CarteBleue,
        Dankort,
        [EnumMember(Value = "Diners Club")] DinersClub,
        Discover,
        [EnumMember(Value = "JCB")] Jcb,
        [EnumMember(Value = "Laser")] Laser,
        Maestro,
        Mastercard,
        Unionpay,
        Visa
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderLineDetailsType
    {
        [EnumMember(Value = "physical")] Physical,
        [EnumMember(Value = "discount")] Discount,
        [EnumMember(Value = "digital")] Digital,
        [EnumMember(Value = "shipping_fee")] ShippingFee,
        [EnumMember(Value = "store_credit")] StoreCredit,
        [EnumMember(Value = "gift_card")] GiftCard,
        [EnumMember(Value = "surcharge")] Surcharge,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderLineStatus
    {
        [EnumMember(Value = "created")] Created,
        [EnumMember(Value = "paid")] Paid,
        [EnumMember(Value = "authorized")] Authorized,
        [EnumMember(Value = "canceled")] Canceled,
        [EnumMember(Value = "shipping")] Shipping,
        [EnumMember(Value = "completed")] Completed,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        [EnumMember(Value = "created")] Created,
        [EnumMember(Value = "paid")] Paid,
        [EnumMember(Value = "authorized")] Authorized,
        [EnumMember(Value = "canceled")] Canceled,
        [EnumMember(Value = "shipping")] Shipping,
        [EnumMember(Value = "completed")] Completed,
        [EnumMember(Value = "expired")] Expired
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SequenceType
    {
        [EnumMember(Value = "oneoff")] OneOff,
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "recurring")] Recurring
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Resource
    {
        [EnumMember(Value = "orders")] Orders,
        [EnumMember(Value = "payments")] Payments
    }
}
