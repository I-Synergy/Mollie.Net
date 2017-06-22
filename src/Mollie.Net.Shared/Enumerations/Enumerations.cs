using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Mollie.Net.Enumerations
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
    public enum PaymentMethod
    {
        [EnumMember(Value = "ideal")]
        Ideal,
        [EnumMember(Value = "creditcard")]
        CreditCard,
        [EnumMember(Value = "mistercash")]
        MisterCash,
        [EnumMember(Value = "sofort")]
        Sofort,
        [EnumMember(Value = "banktransfer")]
        BankTransfer,
        [EnumMember(Value = "directdebit")]
        DirectDebit,
        [EnumMember(Value = "belfius")]
        Belfius,
        [EnumMember(Value = "bitcoin")]
        Bitcoin,
        [EnumMember(Value = "podiumcadeaukaart")]
        PodiumCadeaukaart,
        [EnumMember(Value = "paypal")]
        PayPal,
        [EnumMember(Value = "paysafecard")]
        PaySafeCard,
        [EnumMember(Value = "kbc")]
        Kbc,
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
        Cancelled,
        Pending,
        Paid,
        PaidOut,
        Refunded,
        Expired,
        Failed,
        Charged_Back
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
        Refunded
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
        Cancelled,
        Suspended,
        Completed
    }
}
