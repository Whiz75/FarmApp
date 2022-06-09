

namespace FarmApp.Models
{
    public class Address
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Id#")]
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public int Code { get; set; }
    }
}
