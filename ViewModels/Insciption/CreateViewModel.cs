using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateApp.Models;

namespace RealEstateApp.ViewModels.Insciption
{
    public class CreateViewModel
    {
        public Inscription NewInscription { get; set; }
        public int SelectedBuyerId { get; set; }
        public int SelectedSellerId { get; set; }
        public List<SelectListItem> AvailableBuyers { get; set; }
        public List<SelectListItem> AvailableSellers { get; set; }
    }
}
