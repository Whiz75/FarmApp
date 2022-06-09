

using System.Collections.Generic;

namespace FarmApp.Models
{
    public class Farm
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Id#")]
        public int Id { get; set; }
        public string Name { get; set; }

        //
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<Customer> Customer { get; set; }
    }
}
