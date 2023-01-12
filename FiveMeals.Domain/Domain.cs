using FiveMeals.Domain.Model;

namespace FiveMeals.Domain
{
    public class Domain : IDomain
    {
        private IData _data;

        public Domain(IData data)
        {
            _data = data;
        }
        public User? CreateUser(User userIn)
        {
            if (_data.CheckUserAvailability(userIn))
            {
                return _data.CreateUser(userIn);
            }
            return null;
        }

        public IEnumerable<User>? GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        public User? GetUser(int id)
        {
            return _data.GetUser(id);
        }

        public Table CreateTable(Table tableIn)
        {
            return _data.CreateTable(tableIn);
        }
        public IEnumerable<Table>? GetAllTables() { 
            return _data.GetAllTables();
        }
        public Table? GetTable(int id)
        {
            return _data.GetTable(id);
        }

        public Restaurant CreateRestaurant(Restaurant RestaurantIn)
        {
            return _data.CreateRestaurant(RestaurantIn);
        }
        public IEnumerable<Restaurant>? GetAllRestaurants()
        {
            return _data.GetAllRestaurants();
        }
        public Restaurant? GetRestaurant(int id)
        {
            return _data.GetRestaurant(id);
        }


        public IEnumerable<Category>? GetCategoriesFromRestaurant(int restaurantId)
        {
            return _data.GetCategoriesFromRestaurant(restaurantId);
        }

        public Category CreateCategory(Category category)
        {
            return _data.CreateCategory(category);
        }

        public IEnumerable<Category>? GetAllCategories()
        {
            return _data.GetAllCategories();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _data.GetAllProducts();
        }

        public IEnumerable<Product> GetProductsFromCategoryId(int CategoryId)
        {
            return _data.GetProductsFromCategoryId(CategoryId);
        }

        public Product CreateProduct(Product productIn)
        {
            return _data.CreateProduct(productIn);
        }

        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int RestaurantId)
        {
            return _data.GetCategoriesWithProductsFromRestaurant(RestaurantId);
        }

        public Login CheckLogin(Login login)
        {
            return _data.CheckLogin(login);
        }

        public IEnumerable<int>? GetTableFromRestaurant(int id)
        {
            return _data.GetTableFromRestaurant(id);
        }

        public IEnumerable<OrderProduct> getOrderProducts(long tableId)
        {
            return _data.getOrderProducts(tableId);
        }

        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts, long userId)
        {
            _data.insertOrderProducts(orderProducts,userId);
        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts, long userId)
        {
            _data.deleteOrderProducts(orderProducts, userId);
        }

        public IEnumerable<Favorite> GetFavorites(long userId)
        {
            return _data.GetFavorites(userId); 
        }

        public void insertFavorite(IEnumerable<Favorite> favorites, long userId)
        {
            _data.insertFavorite(favorites, userId);
        }

        public void deleteFavorite(long favorites, long userId)
        {
            _data.deleteFavorite(favorites, userId);    
        }
    }
}