using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modelos.Add
{
    public class Address
    {
        [JsonPropertyName("address1")]
        public string? address1 { get; set; }

        [JsonPropertyName("address2")]
        public string? address2 { get; set; }

        [JsonPropertyName("city")]
        public string? city { get; set; }

        [JsonPropertyName("postalCode")]
        public string? postalCode { get; set; }

        [JsonPropertyName("preferred")]
        public bool preferred { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? CreationDate { get; set; }
    }
}