using System;
using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mollie.Models.Mandate
{
    public class MandateResponse : IResponseObject
    {
        /// <summary>
        /// Indicates the response contains a mandate object. Will always contain mandate for this endpoint.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Unique identifier of you mandate.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Current status of mandate.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MandateStatus Status { get; set; }

        /// <summary>
        /// Payment method of the mandate. Possible values: directdebit creditcard
        /// </summary>
        public PaymentMethods Method { get; set; }

        /// <summary>
        /// Mandate details that are different per payment method. Available fields depend on that payment method.
        /// </summary>
        public MandateDetails Details { get; set; }

        /// <summary>
        /// The mandate’s custom reference, if this was provided when creating the mandate.
        /// </summary>
        public string MandateReference { get; set; }

        /// <summary>
        /// The signature date of the mandate in YYYY-MM-DD format.
        /// </summary>
        public string SignatureDate { get; set; }

        /// <summary>
        /// DateTime when mandate was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// An object with several URL objects relevant to the mandate. Every URL object will contain an href and a type field.
        /// </summary>
        [JsonProperty("_links")]
        public MandateResponseLinks Links { get; set; }
    }
}