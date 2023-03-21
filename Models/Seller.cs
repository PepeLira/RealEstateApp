using System.ComponentModel.DataAnnotations;
namespace RealEstateApp.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public int RoyaltyPer { get; set; } // % de derecho
        public int UnaccreditedRoyaltyPer { get; set; } // % de derecho no acreditado
    }
}
