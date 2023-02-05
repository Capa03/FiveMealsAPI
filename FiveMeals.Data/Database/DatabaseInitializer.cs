using FiveMeals.Domain.Model;

namespace FiveMeals.Data.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DataBaseContext context)
        {

            //Restaurant

            if (context.Restaurants.Any())
            {
                return;   // DB has been seeded
            }

            Restaurant restaurant1 = new Restaurant();
            restaurant1.Id = 1;
            restaurant1.Name = "Pulo do Lobo";

            Restaurant restaurant2 = new Restaurant();
            restaurant2.Id = 2;
            restaurant2.Name = "Burger King";

            context.Restaurants.Add(restaurant1);
            context.Restaurants.Add(restaurant2);
            context.SaveChanges();


            //Tables

            if (context.Tables.Any())
            {
                return;   // DB has been seeded
            }

            for (int i = 0; i<10 ;i++)
            {
                Table table = new Table();
                table.RestaurantID = 1;
               
                context.Tables.Add(table);
                context.SaveChanges();
            }

            for (int i = 0; i < 10; i++)
            {
                Table table = new Table();
                table.RestaurantID = 2;

                context.Tables.Add(table);
                context.SaveChanges();
            }



            //Category

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }


            Category category;
            category = new Category
            {
                RestaurantId = 1,
                CategoryName = "Carne"
            };
            context.Categories.Add(category);
            context.SaveChanges();
            category = new Category
            {
                RestaurantId = 1,
                CategoryName = "Peixe"
            };
            context.Categories.Add(category);
            context.SaveChanges();
            category = new Category
            {
                RestaurantId = 1,
                CategoryName = "Vegetariano"
            };
            context.Categories.Add(category);
            context.SaveChanges();
            category = new Category
            {
                RestaurantId = 1,
                CategoryName = "Bebidas"
            };
            context.Categories.Add(category);
            context.SaveChanges();
            category = new Category
            {
                RestaurantId = 1,
                CategoryName = "Entradas"
            };
            context.Categories.Add(category);
            context.SaveChanges();
            // Products
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            Product product;
            product = new Product
            {
                Name = "Bifana",
                Price = 3.5f,
                Description = " ",
                MinTime = 0.5f,
                MaxTime = 1,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1_0zXE1wScxdn0DbOXYKE-CgpM7y1BtFI",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Burger",
                Price = 4.5f,
                Description = " ",
                MinTime = 10,
                MaxTime = 20,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1c-MFHH_qZew23MctTSD5awnbXInElt9S",
                maxSteps = 8
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Bitoque",
                Price = 6,
                Description = " ",
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1LQGxf3P06aSjaF1CsdYDb0xPnA2jp5_p",
                maxSteps = 10
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "PicaPau",
                Price = 7,
                Description = " ",
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=147cNPkB0OcP5u4bRthoR6ci7At0CujhA",
                maxSteps = 8
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Salmão",
                Price = 5.5f,
                Description = " ",
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1SmNbsAumK8EyMUYKMcckzNmqJJpDHO1B",
                maxSteps = 12
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Cavala",
                Price = 5,
                Description = " ",
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1wLjDQC0r2HDlwEOE7ESL3dQ3rxSOdIfo",
                maxSteps = 11
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Sardinhas",
                Price = 7,
                Description = " ",
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1LIxNKqxd4Pm4BIW6LQD0lyIZKG7-N2jw",
                maxSteps = 6
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Tofu",
                Price = 6,
                Description = " ",
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Vegetariano",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1el9d-UigHTeofLidLGsUdzvgAUcJVF2n",
                maxSteps = 8
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Salada",
                Price = 3,
                Description = " ",
                MinTime = 5,
                MaxTime = 0,
                CategoryName = "Vegetariano",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1oVeMz6LFflskxZTCNgP9TWAwkoFhpnyo",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Coca-cola",
                Price = 1.5f,
                Description = " ",
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Bebidas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1NiqopfKfi1T3jkdmk22o-uEqVyiKD-Je",
                maxSteps = 1
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Sumol",
                Price = 1.5f,
                Description = " ",
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Bebidas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1QZRDXI3wP1fbrnD0nB-75GDj13e-0-iZ",
                maxSteps = 1
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Queijo",
                Price = 2,
                Description = " ",
                MinTime = 2,
                MaxTime = 0,
                CategoryName = "Entradas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1ZsxgrHaG2WZGrqoOqE32kDmhQ4XhTLMf",
                maxSteps = 1
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Azeitonas",
                Price = 1,
                Description = " ",
                MinTime = 1,
                MaxTime = 0,
                CategoryName = "Entradas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1GJ-RYLa646927CSjglz5YFjtri_LcS13",
                maxSteps = 1
            };
            context.Products.Add(product);

            category = new Category
            {
                RestaurantId = 2,
                CategoryName = "Originals"
            };
            context.Categories.Add(category);
            product = new Product
            {
                Name = "Menu Ibérico",
                Price = 3.5f,
                MinTime = 0.5f,
                MaxTime = 1,
                CategoryName = "Originals",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1yDivLVMYY9FgvhG6fqwBSwvSl_2MzBo8",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Quejo & Caramelo",
                Price = 4.5f,
                MinTime = 10,
                MaxTime = 20,
                CategoryName = "Originals",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1oSZzEgefXK7nk3BpSmMm2ksjCVbPycs6",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "The King Bacon",
                Price = 6f,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Originals",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1irHfyy4KQW1WkWEraT6yARnt3FSDYkBN",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Whopper",
                Price = 7f,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Originals",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=14NcggEzWaZSXlu1mP6UMmmtVkMoSVpWz",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            category = new Category
            {
                RestaurantId = 2,
                CategoryName = "Chicken"
            };
            context.Categories.Add(category);
            product = new Product
            {
                Name = "Queen Cheese",
                Price = 5.5f,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Chicken",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=148-H-K9QZ8yufY75BeRMa6gS5EKliPLE",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);


            product = new Product
            {
                Name = "Chicken Tendercrisp",
                Price = 5f,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Chicken",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1x4YXrc0aVZIqtNOoy97dPbH8EROH8qB5",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Nuggets(x9)",
                Price = 7f,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Chicken",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1J5A9m0qxk8v9bplpG0uJrEMtJHVh9Mb-",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            category = new Category
            {
                RestaurantId = 2,
                CategoryName = "Vegan"
            };
            context.Categories.Add(category);
            product = new Product
            {
                Name = "Long Vegan",
                Price = 6f,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Vegan",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1ViTJa45GgjrPNah9RaoOIgFkrIPBN62e",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Big King Vegan",
                Price = 3f,
                MinTime = 5,
                MaxTime = 0,
                CategoryName = "Vegan",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1lS6JgpyTzvn2_fLD7SoCjHGqFymoGgox",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            category = new Category
            {
                RestaurantId = 2,
                CategoryName = "Drinks"
            };
            context.Categories.Add(category);
            product = new Product
            {
                Name = "Coca-cola",
                Price = 1.5f,
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Drinks",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1NiqopfKfi1T3jkdmk22o-uEqVyiKD-Je",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Orange Juice",
                Price = 1.5f,
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Drinks",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1WEIwlyMseu58y9K1sd2caFMERsTHxbdw",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            category = new Category
            {
                RestaurantId = 2,

                CategoryName = "Entries"
            };
            context.Categories.Add(category);
            product = new Product
            {
                Name = "Cheese Bites",
                Price = 2f,
                MinTime = 2,
                MaxTime = 0,
                CategoryName = "Entries",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1vHo-ne7LfEH5826NDfkJmnZxHGUaxUGg",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            product = new Product
            {
                Name = "Bucket",
                Price = 1f,
                MinTime = 1,
                MaxTime = 0,
                CategoryName = "Entries",
                RestaurantId = 2,
                ImgLink = "https://docs.google.com/uc?id=1s90-bd7774dTZHtwckMj-pgC7epgB21P",
                Description = " ",
                maxSteps = 5
            };
            context.Products.Add(product);

            context.SaveChanges();
        }
    }
}
