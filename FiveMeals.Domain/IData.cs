using FiveMeals.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain
{
    public interface IData
    {

  
        public void CreateTable(Table tableIn);
        public IEnumerable<Table>? GetAllTables();
        public Table? GetTable(int id);

        public IEnumerable<int>? GetTableFromRestaurant(int id);
        public void CreateRestaurant(Restaurant restaurantIn);
        public IEnumerable<Restaurant>? GetAllRestaurants();
        public Restaurant? GetRestaurant(int id);
        
        public Task<IEnumerable<Category?>> GetCategoriesFromRestaurant(int restaurantId);
        public IEnumerable<Category>? GetAllCategories();
        public void CreateCategory(Category category);

        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId);
        public void CreateProduct(Product productIn);
        public Task<IEnumerable<CategoryWithProducts>> GetCategoriesWithProductsFromRestaurant(int restaurantId);

        public IEnumerable<OrderProduct> getOrderProducts(long orderId);
        public Task<IEnumerable<OrderProduct?>> getQueueProductsFromRestaurant(long restaurantId);
        public Task<IEnumerable<OrderProduct?>> getOnProgressProductsFromRestaurant(long restaurantId);
        public IEnumerable<OrderProduct?> getForDeliveryProductsFromRestaurant(long restaurantId);
        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void updateOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void deleteOrderProducts(IEnumerable<long> orderProducts);
        public IEnumerable<Favorite?> GetFavorites(String userEmail);
        public Favorite? getFavoriteFromProductIdAndEmail(Favorite favorite);
        public void insertFavorite(Favorite favorite);
        public void deleteFavorite(Favorite favorite);

        public void insertOrder(Order order);
        public Task<Order?> GetOrder(Order order);
        public void closeOrder(long orderId);
    }
}
