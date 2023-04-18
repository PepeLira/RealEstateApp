using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateApp.Models;

namespace RealEstateApp.ViewModels.Insciption
{
    public class InscriptionCreateViewModel
    {
        public Inscription NewInscription { get; set; }
        public List<Buyer> NewBuyers { get; set; }
        public List<Seller> NewSellers { get; set; }
    }
}
