using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
