namespace FarmApp.Models
{
        using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

        public partial class Customer
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("createdDate")]
            public DateTimeOffset CreatedDate { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("farm")]
            public List<Farm> Farm { get; set; }
        }

}
