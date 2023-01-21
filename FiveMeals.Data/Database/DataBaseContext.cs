using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Data.Database
{
    public class DataBaseContext : IdentityUserContext<IdentityUser>, IData
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }

        public string _dbPath { get; }

        public DataBaseContext()
        {
            _dbPath = "FiveMeals.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={_dbPath}");



        public void CreateCategory(Category category)
        {
            Categories.Add(category);
            SaveChanges();
        }

        public void CreateProduct(Product productIn)
        {
            Products.Add(productIn);
            SaveChanges();
        }

        public void CreateRestaurant(Restaurant restaurantIn)
        {
            Restaurants.Add(restaurantIn);
            SaveChanges();
        }

        public void CreateTable(Table tableIn)
        {
            Tables.Add(tableIn);
            SaveChanges();
        }

        public void deleteFavorite(long productId, long userId)
        {
            Product product = Products.Find(productId);

            Favorite favorite = (Favorite)Favorites.Where(f => f.productID == productId && f.userID == userId);

            Favorites.Remove(favorite);
            SaveChanges();
        }



        public IEnumerable<Category>? GetAllCategories()
        {
            return Categories.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products.ToList();
        }

        public IEnumerable<Restaurant>? GetAllRestaurants()
        {
            return Restaurants.ToList();
        }

        public IEnumerable<Table>? GetAllTables()
        {
            return Tables.ToList();
        }

        public IEnumerable<Category>? GetCategoriesFromRestaurant(int restaurantId)
        {
            return Categories.Where(category => category.RestaurantId == restaurantId);
        }

        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int restaurantId)
        {
            IEnumerable<Category> categoriesFromRestaurant = GetCategoriesFromRestaurant(restaurantId);
            List<CategoryWithProducts> results = new List<CategoryWithProducts>();
            foreach (Category category in categoriesFromRestaurant)
            {
                CategoryWithProducts categoryWithProducts = new CategoryWithProducts();
                categoryWithProducts.Id = category.Id;
                categoryWithProducts.RestaurantId = restaurantId;
                categoryWithProducts.CategoryName = category.CategoryName;
                categoryWithProducts.products = (List<Product>)Products.Where(product => product.CategoryName == categoryWithProducts.CategoryName && product.RestaurantId == restaurantId);
                results.Add(categoryWithProducts);
            }
            return results;
        }

        public IEnumerable<Favorite> GetFavorites(long userId)
        {
            return Favorites.Where(fav => fav.userID == userId);
        }

        public IEnumerable<OrderProduct> getOrderProducts(long tableId)
        {
            return OrderProducts.Where(order => order.tableID == tableId);
        }

        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId)
        {

            Category category = (Category)Categories.Where(c => c.Id == categoryId);

            return Products.Where(product => product.CategoryName == category.CategoryName && product.RestaurantId == category.RestaurantId);
        }

        public Restaurant? GetRestaurant(int id)
        {
            return (Restaurant?)Restaurants.Where(res => res.Id == id);
        }

        public Table? GetTable(int id)
        {
            return (Table?)Tables.Where(t => t.Id == id);
        }

        public IEnumerable<int>? GetTableFromRestaurant(int id)
        {
            return (IEnumerable<int>?)Tables.Where(t => t.RestaurantID == id);
        }

        public void insertFavorite(IEnumerable<Favorite> favorites, long userId)
        {
            Product product = Products.Find();

            Favorite favorite = (Favorite)Favorites.Where(f => favorites.Where(f => f.userID == userId).Equals(f.userID == userId));

            Favorites.Add(favorite);
            SaveChanges();
        }

        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            throw new NotImplementedException();
        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts)
        {
            foreach (long id in orderProducts)
            {

                OrderProducts.Remove((OrderProduct)OrderProducts.Where(order => order.orderProductID == id));
            }
        }
        
    }
}
