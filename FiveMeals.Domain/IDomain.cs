using FiveMeals.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain
{
    public interface IDomain
    {
        public void CreateTable(Table tableIn);
        public IEnumerable<Table>? GetAllTables();
        public Table? GetTable(int id);
        public IEnumerable<int>? GetTableFromRestaurant(int id);
        public void CreateRestaurant(Restaurant restaurantIn);
        public IEnumerable<Restaurant>? GetAllRestaurants();
        public Restaurant? GetRestaurant(int id);
        
        public IEnumerable<Category>? GetCategoriesFromRestaurant(int RestaurantId);
        public IEnumerable<Category>? GetAllCategories();
        public void CreateCategory(Category categoryIn);

        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsFromCategoryId(int CategoryId);
        public void CreateProduct(Product productIn);
        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int RestaurantId);
       
        public IEnumerable<OrderProduct> getOrderProducts(long orderId);
        public IEnumerable<OrderProduct> getQueueProductsFromRestaurant(long restaurantId);
        public IEnumerable<OrderProduct> getOnProgressProductsFromRestaurant(long restaurantId);
        public IEnumerable<OrderProduct> getForDeliveryProductsFromRestaurant(long restaurantId);
        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void updateOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void deleteOrderProducts(IEnumerable<long> orderProducts);

        public IEnumerable<Favorite> GetFavorites(long userId);

        public void insertFavorite(IEnumerable<Favorite> favorites, long userId);
        public void deleteFavorite(long favorites, long userId);

        public Order GetOrder(Order order);
    }
}
