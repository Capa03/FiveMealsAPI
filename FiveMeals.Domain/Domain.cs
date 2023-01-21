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
      

        public void CreateTable(Table tableIn)
        {
             _data.CreateTable(tableIn);
        }
        public IEnumerable<Table>? GetAllTables() { 
            return _data.GetAllTables();
        }
        public Table? GetTable(int id)
        {
            return _data.GetTable(id);
        }

        public void CreateRestaurant(Restaurant RestaurantIn)
        {
             _data.CreateRestaurant(RestaurantIn);
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

        public void CreateCategory(Category category)
        {
             _data.CreateCategory(category);
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

        public void CreateProduct(Product productIn)
        {
             _data.CreateProduct(productIn);
        }

        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int RestaurantId)
        {
            return _data.GetCategoriesWithProductsFromRestaurant(RestaurantId);
        }

        

        public IEnumerable<int>? GetTableFromRestaurant(int id)
        {
            return _data.GetTableFromRestaurant(id);
        }

        public IEnumerable<OrderProduct> getOrderProducts(long tableId)
        {
            return _data.getOrderProducts(tableId);
        }

        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            _data.insertOrderProducts(orderProducts);
        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts)
        {
            _data.deleteOrderProducts(orderProducts);
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