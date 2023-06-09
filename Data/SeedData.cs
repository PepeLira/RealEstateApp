﻿using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public static class SeedData
    {
        public static DateTime getRandomDate()
        {
            return DateTime.Now.AddDays(new Random().Next(100, 500));
        }

        public static void AddSeedData(ApplicationDbContext context)
        {
            Random random = new Random();

            if (context.Inscriptions.Any())
            {
                return;   // DB has been seeded
            }

            var buyer_1 = new Buyer
            {
                Rut = "19.434.234-0",
                RoyaltyPercentage = random.Next(1, 100),
                UnaccreditedRoyaltyPercentage = false
            };

            var buyer_2 = new Buyer
            {
                Rut = "19.434.300-0",
                RoyaltyPercentage = random.Next(1, 100),
                UnaccreditedRoyaltyPercentage = false
            };

            context.Buyers.AddRange(buyer_1,buyer_2);

            var seller_1 = new Seller
            {
                Rut = "19.434.300-0",
                RoyaltyPercentage = random.Next(1, 100),
                UnaccreditedRoyaltyPercentage = false
            };

            var seller_2 = new Seller
            {
                Rut = "19.434.234-0",
                RoyaltyPercentage = random.Next(1, 100),
                UnaccreditedRoyaltyPercentage = false
            };

            context.Sellers.AddRange(seller_1,seller_2);

            var communes = new Commune[]
            {
                new Commune{Name="Las Condes"},
                new Commune{Name="Ñuñoa"},
                new Commune{Name="Vitacura"},
                new Commune{Name="Providencia"},
                new Commune{Name="La Reina"}
            };

            context.Communes.AddRange(communes);

            context.Inscriptions.AddRange(
                new Inscription {
                    Cne = "Compraventa",
                    Commune = "Las Condes",
                    Block = random.Next(1, 100),
                    Property = 22,
                    Sellers = new List<Seller> { seller_1 },
                    Buyers = new List<Buyer> { buyer_1 },
                    Fojas = 1,
                    InscriptionNumber = random.Next(1, 100),
                    InscriptionDate = getRandomDate()
                },
                new Inscription
                {
                    Cne = "Compraventa",
                    Commune = "Nunoa",
                    Block = random.Next(1, 100),
                    Property = 11,
                    Sellers = new List<Seller> { seller_2 },
                    Buyers = new List<Buyer> { buyer_2 },
                    Fojas = 2,
                    InscriptionNumber = 2,
                    InscriptionDate = getRandomDate()
                }
            );

            DateTime inscriptionDate = getRandomDate();

            context.MultiOwners.AddRange(
                new MultiOwner
                {
                    Commune = "Las Condes",
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "19.434.234-0",
                    RoyaltyPercentage = random.Next(1, 100),
                    Fojas = random.Next(1, 100),
                    InscriptionDate = inscriptionDate,
                    InscriptionYear = inscriptionDate.Year,
                    InscriptionNumber = random.Next(1, 100),
                    InitialEffectiveYear = random.Next(2020, 2050),
                    FinalEffectiveYear = random.Next(2020, 2050)
                },
                new MultiOwner
                {
                    Commune = "Nunoa",
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "19.434.224-2",
                    RoyaltyPercentage = random.Next(1, 100),
                    Fojas = random.Next(1, 100),
                    InscriptionDate = inscriptionDate,
                    InscriptionYear = inscriptionDate.Year,
                    InscriptionNumber = random.Next(1, 100),
                    InitialEffectiveYear = random.Next(2020, 2050),
                    FinalEffectiveYear = random.Next(2020, 2050)
                },
                new MultiOwner
                {
                    Commune = "Vitacura",
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "19.434.233-5",
                    RoyaltyPercentage = 25.3,
                    Fojas = random.Next(1, 100),
                    InscriptionDate = inscriptionDate,
                    InscriptionYear = inscriptionDate.Year,
                    InscriptionNumber = random.Next(1, 100),
                    InitialEffectiveYear = random.Next(2020, 2050),
                }
            );         

            context.SaveChanges();
        }
    }
}
