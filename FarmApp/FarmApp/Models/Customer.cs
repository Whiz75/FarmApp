namespace FarmApp.Models
{
        using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

        public partial class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }
    
        }

}
