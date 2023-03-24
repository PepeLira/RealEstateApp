using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            
        }
        public static DateTime getRandomDate()
        {
            return DateTime.Now.AddDays(new Random().Next(100, 500));
        }
        public static void AddSeedData(ApplicationDbContext context)
        {
            Random random = new Random();

            // Look for any students.
            if (context.Inscriptions.Any())
            {
                return;   // DB has been seeded
            }

            context.Buyers.AddRange(
                new Buyer
                {
                    Rut = "19.434.234-0",
                    RoyaltyPercentage = random.Next(1, 100),
                    UnaccreditedRoyaltyPercentage = random.Next(1, 100)
                },
                new Buyer
                {
                    Rut = "19.434.300-0",
                    RoyaltyPercentage = random.Next(1, 100),
                    UnaccreditedRoyaltyPercentage = random.Next(1, 100)
                }
            );

            context.Sellers.AddRange(
                new Seller
                {
                    Rut = "19.434.234-0",
                    RoyaltyPercentage = random.Next(1, 100),
                    UnaccreditedRoyaltyPercentage = random.Next(1, 100)
                },
                new Seller
                {
                    Rut = "19.434.434-0",
                    RoyaltyPercentage = random.Next(1, 100),
                    UnaccreditedRoyaltyPercentage = random.Next(1, 100)
                }
            );

            context.SaveChanges();

            Seller seller_1 = context.Sellers.ToList()[0];
            Seller seller_2 = context.Sellers.ToList()[1];

            Buyer buyer_1 = context.Buyers.ToList()[0];
            Buyer buyer_2 = context.Buyers.ToList()[1];


            context.Inscriptions.AddRange(
                new Inscription {
                    Cne = "Compraventa",
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",
                    Seller = seller_1,
                    Buyer = buyer_1,
                    Fojas = "Foja 1",
                    InscriptionNumber = random.Next(1, 100),
                    InscriptionDate = getRandomDate(),
                    SellerId = seller_1.Id,
                    BuyerId = buyer_1.Id
                },
                new Inscription
                {
                    Cne = "Compraventa",
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",
                    Seller = seller_2,
                    Buyer = buyer_2,
                    Fojas = "Foja 2",
                    InscriptionNumber = 2,
                    InscriptionDate = getRandomDate(),
                    SellerId = seller_2.Id,
                    BuyerId = buyer_2.Id
                }
            );

            DateTime inscriptionDate = getRandomDate();

            context.MultiOwners.AddRange(
                new MultiOwner
                {
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "Juanin",
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
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "Juanin2",
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
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = random.Next(1, 100),
                    Owner = "Juanin3",
                    RoyaltyPercentage = random.Next(1, 100),
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
