﻿using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public int RoyaltyPercentage { get; set; } // % de derecho
        [Required]
        public int UnaccreditedRoyaltyPercentage { get; set; } // % de derecho no acreditado
        public ICollection<Inscription> Inscriptions { get; set; }
    }
}
