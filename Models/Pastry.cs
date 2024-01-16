using System.ComponentModel.DataAnnotations;

namespace BakeryAPI.Models
{
    public class Pastry
    {
        [Key]
        public int PastryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Price { get; set; }

    }
}
