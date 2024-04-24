using WebShopJewel.Models;

namespace WebShopJewel.Data
{
    public static class SeedInitialData
    {
        public static void Initialize(AppDbContext context)
        {
            if(context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new() {Name="Ring"},
                new() {Name="Neckless"},
                new() {Name="Armband"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new Product[]
            {
                new() 
                {                  
                    Name = "Gold Pearl", 
                    Description = "Golden armband with pearls",   
                    Price = 10.99m,
                    CategoryId = 3,
                    Image = "~/images/ArmBands/GoldPearlsArmBand.jpg"
                },
                new()
                {
                    Name = "Silver Band",
                    Description = "Silver Armband",
                    Price = 15.99m,
                    CategoryId = 3,
                    Image = "~/images/ArmBands/SilverArmband.jpg"
                },
                new()
                {
                    Name = "Steel Band",
                    Description = "Steel Armband",
                    Price = 19m,
                    CategoryId = 3,
                    Image = "~/images/ArmBands/SteelArmband.jpg"
                },
                new()
                {
                    Name = "Thanos Band",
                    Description = "Thanos armband marvel",
                    Price = 5m,
                    CategoryId = 3,
                    Image = "~/images/ArmBands/ThanosArmband.jpg"
                },
                new()
                {
                    Name = "Gold Arrow",
                    Description = "Golden arrow neckless",
                    Price = 25m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/ArrowGoldNeckless.jpg"
                },
                new()
                {
                    Name = "Silver Arrow",
                    Description = "Silver arrow neckless",
                    Price = 18m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/ArrowSilverNeckless.jpg"
                },
                new()
                {
                    Name = "Steel Arrow",
                    Description = "Steel arrow neckless",
                    Price = 14m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/ArrowSteelNeckless.jpg"
                },
                new()
                {
                    Name = "Black Panther",
                    Description = "Black panther neckless marvel",
                    Price = 20m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/BlackPantherNeckless.jpg"
                },
                new()
                {
                    Name = "Blue Heart",
                    Description = "Blue heart neckless",
                    Price = 29.99m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/BlueHeartNeckless.jpg"
                },
                new()
                {
                    Name = "Red Heart",
                    Description = "Red heart neckless",
                    Price = 29.99m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/RedHeartNeckless.jpg"
                },
                new()
                {
                    Name = "Slytherin",
                    Description = "Slytherin neckless Harry Potter",
                    Price = 10.99m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/SlytherinNeckless.jpg"
                },
                new()
                {
                    Name = "Gryffindor",
                    Description = "Gryffindor neckless Harry Potter",
                    Price = 10.99m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/GryffindorNeckless.jpg"
                },
                new()
                {
                    Name = "Stark",
                    Description = "Stark family symbol Game of thrones",
                    Price = 14m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/StarkNeckless.jpg"
                },
                new()
                {
                    Name = "The Hand",
                    Description = "The hand symbol Game of thrones",
                    Price = 14m,
                    CategoryId = 2,
                    Image = "~/images/Necklesses/TheHandNeckless.jpg"
                },
                new()
                {
                    Name = "Hours Eye",
                    Description = "Hours eye signet ring",
                    Price = 10.99m,
                    CategoryId = 1,
                    Image = "~/images/Rings/HoursEyeRing.jpg"
                },
                new()
                {
                    Name = "Black Pearl",
                    Description = "Black pearl signet ring",
                    Price = 40m,
                    CategoryId = 1,
                    Image = "~/images/Rings/KlackRingBlackPearl.jpg"
                },
                new()
                {
                    Name = "Blue",
                    Description = "Blue signet ring",
                    Price = 35m,
                    CategoryId = 1,
                    Image = "~/images/Rings/KlackRingBlue.jpg"
                },
                new()
                {
                    Name = "Gold",
                    Description = "Golden signet ring",
                    Price = 60m,
                    CategoryId = 1,
                    Image = "~/images/Rings/KlackRingGold.jpg"
                },
                new()
                {
                    Name = "Red Pearl",
                    Description = "Red pearl signet ring",
                    Price = 45m,
                    CategoryId = 1,
                    Image = "~/images/Rings/KlackRingRedPearl.jpg"
                },
                new()
                {
                    Name = "Naruto Blue",
                    Description = "Naruto blue signet ring",
                    Price = 25.49m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingB.jpg"
                },
                new()
                {
                    Name = "Naruto Green",
                    Description = "Naruto green signet ring",
                    Price = 27.99m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingG.jpg"
                },
                new()
                {
                    Name = "Naruto Light Red",
                    Description = "Naruto light red signet ring",
                    Price = 26m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingLightRed.jpg"
                },
                new()
                {
                    Name = "Naruto Orange",
                    Description = "Naruto orange signet ring",
                    Price = 21.49m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingO.jpg"
                },
                new()
                {
                    Name = "Naruto Purple",
                    Description = "Naruto purple signet ring",
                    Price = 21m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingP.jpg"
                },
                new()
                {
                    Name = "Naruto Red",
                    Description = "Naruto Red signet ring",
                    Price = 24m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingRed.jpg"
                },
                new()
                {
                    Name = "Naruto Turquoise",
                    Description = "Naruto turquoise signet ring",
                    Price = 25.50m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingT.jpg"
                },
                new()
                {
                    Name = "Naruto Yellow",
                    Description = "Naruto yellow signet ring",
                    Price = 23.49m,
                    CategoryId = 1,
                    Image = "~/images/Rings/NarutoRingY.jpg"
                },
                new()
                {
                    Name = "Thanos",
                    Description = "Thanos signet ring marvel",
                    Price = 27.99m,
                    CategoryId = 1,
                    Image = "~/images/Rings/ThanosRing.jpg"
                },
                new()
                {
                    Name = "Tree of Life",
                    Description = "Tree of life gold sigent ring",
                    Price = 33m,
                    CategoryId = 1,
                    Image = "~/images/Rings/TreeOfLifeRing.jpg"
                },
                new()
                {
                    Name = "Valknut",
                    Description = "Valknut signet ring",
                    Price = 50m,
                    CategoryId = 1,
                    Image = "~/images/Rings/ValknutSilverRing.jpg"
                }

            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
