namespace FarmApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Farm Farm { get; set; }
        public int FarmId { get; set; }
    }
}
