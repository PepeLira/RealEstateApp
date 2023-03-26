﻿using System.ComponentModel.DataAnnotations;
namespace RealEstateApp.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RoyaltyPercentage { get; set; } // % de derecho
        public int UnaccreditedRoyaltyPercentage { get; set; } // % de derecho no acreditado
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
