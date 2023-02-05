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


        public async Task<IEnumerable<Category?>> GetCategoriesFromRestaurant(int restaurantId)
        {
            return await _data.GetCategoriesFromRestaurant(restaurantId);
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

        public async Task<IEnumerable<CategoryWithProducts>> GetCategoriesWithProductsFromRestaurant(int RestaurantId)
        {
            return await _data.GetCategoriesWithProductsFromRestaurant(RestaurantId);
        }

        

        public IEnumerable<int>? GetTableFromRestaurant(int id)
        {
            return _data.GetTableFromRestaurant(id);
        }



        public IEnumerable<OrderProduct> getOrderProducts(long orderId)
        {
            return _data.getOrderProducts(orderId);
        }

        public async  Task<IEnumerable<OrderProduct?>> getQueueProductsFromRestaurant(long restaurantId)
        {
            return await _data.getQueueProductsFromRestaurant(restaurantId);
        }

        public async Task<IEnumerable<OrderProduct>> getOnProgressProductsFromRestaurant(long restaurantId)
        {
            return await _data.getOnProgressProductsFromRestaurant(restaurantId);
        }
        public IEnumerable<OrderProduct> getForDeliveryProductsFromRestaurant(long restaurantId)
        {
            return _data.getForDeliveryProductsFromRestaurant(restaurantId);
        }

        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            _data.insertOrderProducts(orderProducts);
        }

        public void updateOrderProducts(IEnumerable<OrderProduct> orderProductsIn)
        {
            _data.updateOrderProducts(orderProductsIn);

            bool missingPay = false;

            foreach (OrderProduct op in _data.getOrderProducts(orderProductsIn.FirstOrDefault().orderId)) {
                if (!op.paid)
                {
                    missingPay = true; break;
                }
            }

            if (!missingPay)
            {
                _data.closeOrder(orderProductsIn.FirstOrDefault().orderId);
            }


        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts)
        {
            _data.deleteOrderProducts(orderProducts);
        }

        public IEnumerable<Favorite> GetFavorites(String userEmail)
        {
            return _data.GetFavorites(userEmail); 
        }

        public void checkFavorite(Favorite favorite)
        {
            Favorite savedFavorite = _data.getFavoriteFromProductIdAndEmail(favorite);
            if (savedFavorite != null)
            {
                _data.deleteFavorite(savedFavorite);
            }else
            {
                _data.insertFavorite(favorite);
            }
        }


        public async Task<Order> GetOrder(Order order)
        {
            Order? exists= await _data.GetOrder(order);
            if(exists == null)
            {
                _data.insertOrder(order);
            }

            return await _data.GetOrder(order);
        }

        
    }
}