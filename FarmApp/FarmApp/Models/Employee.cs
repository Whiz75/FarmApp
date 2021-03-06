

using FarmApp.Models;
using System;
using System.Collections.Generic;

namespace farm_web_api.models
{
    public class Employee
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Id#")]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        //
        public int FarmId { get; set; }
        public List<Farm> Farm { get; set; }

    }
}
