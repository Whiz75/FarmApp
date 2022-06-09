

using System;

namespace FarmApp.Models
{
    public class Driver
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Id#")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        //
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
    }
}
