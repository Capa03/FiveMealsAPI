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
using System.Xml.Linq;

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
        public DbSet<Order> Orders { get; set; }

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

            Favorite favorite = Favorites.Where(f => f.productID == productId && f.userID == userId).FirstOrDefault();

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

        public async Task<IEnumerable<Category?>> GetCategoriesFromRestaurant(int restaurantId)
        {
            return await Categories.Where(category => category.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<IEnumerable<CategoryWithProducts>> GetCategoriesWithProductsFromRestaurant(int restaurantId)
        {
            IEnumerable<Category?> categoriesFromRestaurant = await GetCategoriesFromRestaurant(restaurantId);

            List<CategoryWithProducts> results = new List<CategoryWithProducts>();

            foreach (Category? category in categoriesFromRestaurant)
            {
                CategoryWithProducts categoryWithProducts = new CategoryWithProducts();
                categoryWithProducts.Id = category.Id;
                categoryWithProducts.RestaurantId = restaurantId;
                categoryWithProducts.CategoryName = category.CategoryName;
                categoryWithProducts.products = await Products.Where(product => product.CategoryName == categoryWithProducts.CategoryName && product.RestaurantId == restaurantId).ToListAsync();
                results.Add(categoryWithProducts);
            }
            return results;
        }

        public IEnumerable<Favorite> GetFavorites(long userId)
        {
            return Favorites.Where(fav => fav.userID == userId);
        }

        public IEnumerable<OrderProduct> getOrderProducts(long orderId)
        {
            return OrderProducts.Where(order => order.orderId == orderId);
        }

        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId)
        {

            Category category = (Category)Categories.Where(c => c.Id == categoryId);

            return Products.Where(product => product.CategoryName == category.CategoryName && product.RestaurantId == category.RestaurantId);
            
        }

        public Restaurant? GetRestaurant(int id)
        {
            return Restaurants.Where(res => res.Id == id).FirstOrDefault();
        }

        public Table? GetTable(int id)
        {
            return Tables.Where(t => t.Id == id).FirstOrDefault();
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
            foreach (OrderProduct orderProduct in orderProducts) {
                Product product = (Product)Products.Single(p => orderProduct.productID == p.Id);
                orderProduct.productName =  product.Name;
                orderProduct.productPrice = product.Price;
                orderProduct.productMinAverageTime = product.MinTime;
                orderProduct.productMaxAverageTime = product.MaxTime;
                orderProduct.imgLink = product.ImgLink;
                orderProduct.orderedTime = DateTime.Now;
                orderProduct.stepsMade = 0;
                orderProduct.maxSteps = product.maxSteps;
                orderProduct.paid = false;
                orderProduct.restaurantId = Restaurants.Single(r => r.Id == (Tables.Single(t => t.Id == (Orders.Single(o => o.Id == orderProduct.orderId).tableId)).RestaurantID)).Id;
                OrderProducts.Add(orderProduct);   
            }
            SaveChanges();
        }

        public async Task<IEnumerable<OrderProduct?>> getQueueProductsFromRestaurant(long restaurantId)
        {
            return await OrderProducts.Where(o => o.restaurantId == restaurantId && !o.paid && o.stepsMade == 0).ToListAsync();
        }

        public async Task<IEnumerable<OrderProduct?>> getOnProgressProductsFromRestaurant(long restaurantId)
        {
            return await OrderProducts.Where(o => o.restaurantId == restaurantId && !o.paid && o.stepsMade > 0 && o.stepsMade < o.maxSteps).ToListAsync();
        }

        public IEnumerable<OrderProduct?> getForDeliveryProductsFromRestaurant(long restaurantId)
        {
            return OrderProducts.Where(o => o.restaurantId == restaurantId && !o.paid && o.stepsMade >= o.maxSteps && !o.delivered);
        }


        public void updateOrderProducts(IEnumerable<OrderProduct> inputOrderProducts)
        {
            foreach (OrderProduct inputOrderProduct in inputOrderProducts)
            {
                OrderProduct orderProduct = OrderProducts.Where(o => o.orderProductID == inputOrderProduct.orderProductID).FirstOrDefault();
                orderProduct.stepsMade = inputOrderProduct.stepsMade;
                orderProduct.paid = inputOrderProduct.paid;
                orderProduct.delivered = inputOrderProduct.delivered;
                OrderProducts.Update(orderProduct);
            }
            SaveChanges();
        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts) 
        {
            foreach (long id in orderProducts)
            {
                OrderProducts.Remove(OrderProducts.Where(order => order.orderProductID == id).FirstOrDefault());
            }
            SaveChanges();
        }

        public void insertOrder(Order order)
        {
            order.Created = DateTime.Now;
            Orders.Add(order);
            SaveChanges();
        }

        public async Task<Order?> GetOrder(Order order)
        {
            return await Orders.OrderByDescending(o => o.Created).Where(o => o.tableId == order.tableId && o.open).FirstOrDefaultAsync();
        }

        public void closeOrder(long orderId)
        {
            Order order = Orders.Where(o => o.Id == orderId).FirstOrDefault();
            order.open = false;
            Orders.Update(order);
            SaveChanges();
        }
    }
}
