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

        public Boolean CheckUserAvailability(User user);
        public User CreateUser(User user);
        public IEnumerable<User>? GetAllUsers();
        public User? GetUser(int id);

        public Table CreateTable(Table tableIn);
        public IEnumerable<Table>? GetAllTables();
        public Table? GetTable(int id);

        public IEnumerable<int>? GetTableFromRestaurant(int id);
        public Restaurant CreateRestaurant(Restaurant restaurantIn);
        public IEnumerable<Restaurant>? GetAllRestaurants();
        public Restaurant? GetRestaurant(int id);
        
        public IEnumerable<Category>? GetCategoriesFromRestaurant(int restaurantId);
        public IEnumerable<Category>? GetAllCategories();
        public Category CreateCategory(Category category);

        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId);
        public Product CreateProduct(Product productIn);
        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int restaurantId);
        public Login CheckLogin(Login login);
        public IEnumerable<OrderProduct> getOrderProducts(long tableId);
        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts, long userId);
        public void deleteOrderProducts(IEnumerable<long> orderProducts, long userId);

        public IEnumerable<Favorite> GetFavorites(long userId);
        public void insertFavorite(IEnumerable<Favorite> favorites, long userId);
        public void deleteFavorite(long favorites,long userId);
    }
}
