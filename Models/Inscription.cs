using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }
        public String Cne { get; set; }
        public String Commune { get; set; } // comuna
        public String Block { get; set; } // Manzana 
        public String Property { get; set; } // predio
        public int Sellers { get; set; } // enajenantes
        public int Buyers { get; set; } // adquirentes
        public String Fojas { get; set; }
        public int InscriptionNumber { get; set; }
        public DateTime InscriptionDate { get; set; } = DateTime.Now;
    }
}
