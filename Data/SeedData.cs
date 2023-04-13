using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context){ }

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

            context.Inscriptions.AddRange(
                new Inscription {
                    Cne = "Compraventa",
                    Commune = "Las Condes",
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",                 
                    Fojas = "Foja 1",
                    InscriptionNumber = random.Next(1, 100),
                    InscriptionDate = getRandomDate()
                },
                new Inscription
                {
                    Cne = "Compraventa",
                    Commune = "Nunoa",
                    Block = random.Next(1, 100),
                    Property = "SomeProperty",                    
                    Fojas = "Foja 2",
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
                    Commune = "Nunoa",
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
                    Commune = "Vitacura",
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
