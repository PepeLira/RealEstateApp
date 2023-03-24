using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }
        public String Cne { get; set; }
        public int Commune { get; set; }
        public int Block { get; set; }
        public String Property { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public String Fojas { get; set; }
        public int InscriptionNumber { get; set; }
        public DateTime InscriptionDate { get; set; } = DateTime.Now;

        public int SellerId { get; set; }
        public int BuyerId { get; set; }
    }
}

/// Model Description
/// 
/// Cne      ==> Codigo de Naturaleza de la Escritura (Compraventa / Regularización de Patrimonio)
/// Commune  ==> Comuna
/// Block    ==> Manzana
/// Property ==> Predio
/// Sellers  ==> Enajenantes
/// Buyers   ==> Adquirentes
/// Fojas
/// InscriptionNumber
/// InscriptionDate