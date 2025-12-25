using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class SubscribeViewModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }

        [Required(ErrorMessage = "Ad Soyad gereklidir.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [RegularExpression(@"^05\d{2}\s?\d{3}\s?\d{2}\s?\d{2}$", ErrorMessage = "Telefon numarası '05' ile başlamalı ve 11 hane olmalıdır.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir gmail/e-posta adresi giriniz.")]
        public string Email { get; set; }
    }

    public class PaymentViewModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Kart numarası gereklidir.")]
        [RegularExpression(@"^(\d{4}\s?){3}\d{4}$", ErrorMessage = "Kart numarası 16 haneli olmalıdır.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Son kullanma tarihi gereklidir.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$", ErrorMessage = "Tarih ay/yıl formatında olmalı (Örn: 12/25).")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV gereklidir.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CVV 3 haneli olmalıdır.")]
        public string CVV { get; set; }
    }
}
