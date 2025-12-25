using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } // Simplified for this project scope, ideally Hashed
        public bool IsAdmin { get; set; }
    }

    public class Package
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Features { get; set; } // JSON or comma-separated string
    }
}
