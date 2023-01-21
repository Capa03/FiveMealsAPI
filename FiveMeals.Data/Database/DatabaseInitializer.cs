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
            context.SaveChanges();
        }
    }
}
