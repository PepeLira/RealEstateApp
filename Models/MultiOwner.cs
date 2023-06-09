﻿using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class MultiOwner
    {
        [Key]
        public int Id { get; set; }
        public String Commune { get; set; }
        public int Block { get; set; }
        public int Property { get; set; }
        public string Owner { get; set; }
        public double RoyaltyPercentage { get; set; }
        public int Fojas { get; set; }
        public DateTime InscriptionDate { get; set; }
        public int InscriptionYear { get; set; }
        public int InscriptionNumber { get; set; }
        public int InitialEffectiveYear { get; set; }
        [DisplayFormat(NullDisplayText = "Indefinido")]
        public int? FinalEffectiveYear { get; set; }
    }
}

/// Model Description
/// 
/// string    Commune               ==> Comuna
/// int       Block                 ==> Manzana 
/// int       Property              ==> Predio
/// string    Owner                 ==> RUT
/// int       RoyaltyPercentage     ==> % de derecho
/// int       Fojas 
/// DateTime  InscriptionDate       ==> Fecha de Inscripcion
/// int       InscriptionYear       ==> Ano de Inscripcion
/// int       InscriptionNumber     ==> N de Inscripcion
/// int       InitialEffectiveYear  ==> Ano Vigencia Inicial
/// int       FinalEffectiveYear    ==> Ano Vigencia Final
