using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public static class SeedData
    {
        public static DateTime getRandomDate()
        {
            return DateTime.Now.AddDays(new Random().Next(100, 500));
        }
        public static void AddData(ApplicationDbContext dbContext)
        {
            Random random = new Random();

            dbContext.Buyers.AddRange(
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

            dbContext.Sellers.AddRange(
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


            dbContext.Inscriptions.AddRange(
                new Inscription {
                    Cne = "Compraventa",
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",
                    Seller = "19.434.234-0",
                    Buyer = "19.434.300-0",
                    Fojas = "Foja 1",
                    InscriptionNumber = random.Next(1, 100),
                    InscriptionDate = getRandomDate()
                },
                new Inscription
                {
                    Cne = "Compraventa",
                    Commune = random.Next(1, 100),
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",
                    Seller = "19.434.234-0",
                    Buyer = "19.434.434-0",
                    Fojas = "Foja 2",
                    InscriptionNumber = 2,
                    InscriptionDate = getRandomDate()
                }
            );

            DateTime inscriptionDate = getRandomDate();

            dbContext.MultiOwners.AddRange(
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

            dbContext.SaveChanges();
        }
    }
}
