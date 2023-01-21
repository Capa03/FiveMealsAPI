using FiveMeals.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Data.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            // Products
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{},
            };

            context.Products.AddRange(products);

            //Restaurant

            if (context.Restaurants.Any())
            {
                return;   // DB has been seeded
            }

            var restaurants = new Restaurant[]
            {
                new Restaurant{},
            };

            context.Restaurants.AddRange(restaurants);

            //Tables

            if (context.Tables.Any())
            {
                return;   // DB has been seeded
            }

            var tables = new Table[]
            {
                new Table{},
            };

            context.Tables.AddRange(tables);

            //OrderProduct

            if (context.OrderProducts.Any())
            {
                return;   // DB has been seeded
            }

            var orderProducts = new OrderProduct[]
            {
                new OrderProduct{},
            };

            context.OrderProducts.AddRange(orderProducts);

            //Favorites

            if (context.Favorites.Any())
            {
                return;   // DB has been seeded
            }

            var favorites = new Favorite[]
            {
                new Favorite{},
            };

            context.Favorites.AddRange(favorites);

            //Category

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
