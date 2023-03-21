using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class MultiOwner
    {
        [Key]
        public int Id { get; set; }
        public string Commune { get; set; } // Comuna
        public int Block { get; set; } // Manzana 
        public int Property { get; set; } // Predio
        public string Owner { get; set; } // RUT
        public int RoyaltyPer { get; set; } // % de derecho
        public int Fojas { get; set; }
        public DateTime InscriptionDate { get; set; } // Fecha de Inscripcion
        public int InscriptionYear { get; set; } // Ano de Inscripcion
        public int InscriptionNumber { get; set; } // N de Inscripcion
        public int InitialEffectiveYear { get; set; } // Ano Vigencia Inicial
        public int FinalEffectiveYear { get; set; } // Ano Vigencia Final
    }
}
