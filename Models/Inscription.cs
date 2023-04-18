using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Inscription
    {
        [Key]
        public int AttentionID { get; set; }
        public String Cne { get; set; }
        public String Commune { get; set; }
        public int Block { get; set; }
        public String Property { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<Buyer>  Buyers { get; set; }
        public String Fojas { get; set; }
        public int InscriptionNumber { get; set; }
        public DateTime InscriptionDate { get; set; } = DateTime.Now;
    }

    public enum CneOptions
    {
        Compraventa,
        RegularizaciónDePatrimonio
    }

}

/// Model Description
/// 
/// AttentionID     ==> N de Atencion
/// Cne             ==> Codigo de Naturaleza de la Escritura (Compraventa / Regularización de Patrimonio)
/// Commune         ==> Comuna
/// Block           ==> Manzana
/// Property        ==> Predio
/// Sellers         ==> Enajenantes
/// Buyers          ==> Adquirentes
/// Fojas
/// InscriptionNumber
/// InscriptionDate