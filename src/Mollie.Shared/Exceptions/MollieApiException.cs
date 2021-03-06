﻿using System;
using Mollie.Models.Error;
using Newtonsoft.Json;

namespace Mollie.Client
{
    public class MollieApiException : Exception
    {
        public MollieErrorMessage Details { get; set; }

        public MollieApiException(string json) : base(ParseErrorMessage(json).ToString())
        {
            Details = ParseErrorMessage(json);
        }

        private static MollieErrorMessage ParseErrorMessage(string json)
        {
            return JsonConvert.DeserializeObject<MollieErrorMessage>(json);
        }
    }
}