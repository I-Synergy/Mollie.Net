using Mollie.Models.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Exceptions
{
    public class MollieException : Exception
    {
        public MollieException(string json) : base(CreateExceptionMessage(ParseErrorJsonResponse(json)))
        {
            this.Details = ParseErrorJsonResponse(json);
        }

        public MollieErrorMessage Details { get; set; }

        private static string CreateExceptionMessage(MollieErrorMessage error)
        {
            if (!string.IsNullOrEmpty(error.Field))
            {
                return $"Error occured in field: {error.Field} - {error.Message}";
            }

            return error.Message;
        }

        private static MollieErrorMessage ParseErrorJsonResponse(string json)
        {
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);

            return new MollieErrorMessage
            {
                Message = jsonObject.error.message,
                Field = jsonObject.error.field,
                Type = jsonObject.error.type
            };
        }
    }
}
