
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using System.Net.WebSockets;

namespace FiveMeals.Data
{
    public class DummyData 
    {
        /*
        private int _userId = 0;
        private int _tableId = 0;
        private int _restaurantId = 0;
        private int _categoryId = 0;
        private int _productId = 0;
        private int _orderProductId = 0;
        private int _favoriteId = 0;

        private Dictionary<int, User> _users = new Dictionary<int, User>();
        private Dictionary<int, Table> _tables = new Dictionary<int, Table>();
        private Dictionary<int, Restaurant> _restaurants = new Dictionary<int, Restaurant>();
        private Dictionary<int, Category> _categories = new Dictionary<int, Category>();
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();
        private Dictionary<int, OrderProduct> _orderProducts = new Dictionary<int, OrderProduct>();
        private Dictionary<int, Favorite> _favorites = new Dictionary<int, Favorite>();

        public DummyData()
        {
            InsertData();
        }

        public User CreateUser(User user)
        {
            user.Id = getNextUserId();
            user.Created = DateTime.Now;
            _users.Add(user.Id, user);
            return user;
        }
        public IEnumerable<User>? GetAllUsers()
        {
            return _users.Values;
        }
        public User? GetUser(int id)
        {
            return _users.GetValueOrDefault(id);
        }

        public Table CreateTable(Table tableIn)
        {
            tableIn.Id = getNextTableId();
            _tables.Add(tableIn.Id, tableIn);
            return tableIn;
        }
        public IEnumerable<Table>? GetAllTables()
        {
            return _tables.Values;
        }
        public Table? GetTable(int id)
        {
            return _tables.GetValueOrDefault(id);
        }

        public IEnumerable<int>? GetTableFromRestaurant(int id)
        {

            List<int> results = new List<int>();
            for (int i = 1; i <= _tables.Count(); i++)
            {
                if (_tables.GetValueOrDefault(i).RestaurantID == id)
                {
                    results.Add(_tables.GetValueOrDefault(i).Id);

                }
            }
            return results;
        }

        public Restaurant CreateRestaurant(Restaurant RestaurantIn)
        {
            RestaurantIn.Id = getNextRestaurantId();
            _restaurants.Add(RestaurantIn.Id, RestaurantIn);
            return RestaurantIn;
        }
        public IEnumerable<Restaurant>? GetAllRestaurants()
        {
            return _restaurants.Values;
        }
        public Restaurant? GetRestaurant(int id)
        {
            return _restaurants.GetValueOrDefault(id);
        }



        // Melhorar (??????)
        public IEnumerable<Category>? GetCategoriesFromRestaurant(int restaurantId)
        {
            List<Category> results = new List<Category>();

            for (int i = 1; i <= _categories.Count; i++)
            {
                if (_categories.GetValueOrDefault(i).RestaurantId == restaurantId)
                {
                    results.Add(_categories.GetValueOrDefault(i));
                }
            }
            return results;
        }



        public IEnumerable<Category>? GetAllCategories()
        {
            return _categories.Values;
        }
        public Category CreateCategory(Category categoryIn)
        {
            categoryIn.Id = getNextCategoryId();
            _categories.Add(categoryIn.Id, categoryIn);
            return categoryIn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products.Values;
        }

        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId)
        {
            List<Product> results = new List<Product>();

            String categoryName = _categories.GetValueOrDefault(categoryId).CategoryName;
            for (int i = 1; i <= _products.Count; i++)
            {
                if (_products.GetValueOrDefault(i).CategoryName == categoryName)
                {
                    results.Add(_products.GetValueOrDefault(i));
                }
            }
            return results;
        }

        public Product CreateProduct(Product productIn)
        {
            productIn.Id = getNextProductId();
            _products.Add(productIn.Id, productIn);
            return productIn;
        }

        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int restaurantId)
        {
            List<CategoryWithProducts> results = new List<CategoryWithProducts>();
            for (int i = 1; i <= _categories.Count; i++)
            {
                Category baseCategory = _categories.GetValueOrDefault(i);
                if (baseCategory.RestaurantId == restaurantId)
                {
                    CategoryWithProducts categoryWithProducts = new CategoryWithProducts();
                    categoryWithProducts.Id = baseCategory.Id;
                    categoryWithProducts.RestaurantId = baseCategory.RestaurantId;
                    categoryWithProducts.CategoryName = baseCategory.CategoryName;
                    categoryWithProducts.products = new List<Product>();

                    for (int j = 1; j <= _products.Count; j++)
                    {
                        Product baseProduct = _products.GetValueOrDefault(j);
                        if (baseProduct.CategoryName == categoryWithProducts.CategoryName)
                        {
                            System.Console.WriteLine(j);
                            System.Console.WriteLine(baseProduct.Name);
                            categoryWithProducts.products.Add(baseProduct);
                        }
                    }
                    results.Add(categoryWithProducts);
                }
            }
            return results;
        }


        public Login CheckLogin(Login login)
        {
            login.match = false;
            for (int i = 1; i <= _users.Count; i++)
            {
                User user = _users.GetValueOrDefault(i);
                if ((login.login == user.Username || login.login == user.Email) && login.password == user.Password)
                {
                    login.match = true;
                    break;
                }
            }

            return login;
        }

        public IEnumerable<OrderProduct> getOrderProducts(long tableId)
        {
            List<OrderProduct> results = new List<OrderProduct> ();
            foreach (OrderProduct order in _orderProducts.Values)
            {
                if (order.tableID == tableId)
                {
                    results.Add(order);
                }
            }
            return results;
        }

        public IEnumerable<Favorite> GetFavorites(long userId)
        {
            List <Favorite> results = new List<Favorite>();
            foreach (Favorite favorite in _favorites.Values)
            {
                if (favorite.userID == userId)
                {
                    results.Add(favorite);
                }
            }
            return results;
        }

        public void insertFavorite(IEnumerable<Favorite> favorites, long userId)
        {
            foreach (Favorite favorite in favorites)
            {
                Product product = _products.GetValueOrDefault((int)favorite.productID);
                //favorite.productID = getNextFavoriteId();
                favorite.userID = userId;
                favorite.restaurantID = product.RestaurantId;
                favorite.productName = product.Name;
                favorite.productPrice = product.Price;
                favorite.productImage = product.ImgLink;
                _favorites.Add((int)favorite.productID,favorite);
            }
        }

        public void deleteFavorite(long productId, long userId)
        {
            foreach (Favorite favorite in _favorites.Values)
            {
                if (favorite.productID == productId && favorite.userID == userId)
                {
                    _favorites.Remove((int)favorite.productID);
                }
                
            }
        }

        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts, long userId)
        {
            foreach (OrderProduct order in orderProducts)
            {
                Product product = _products.GetValueOrDefault((int)order.productID);
                order.orderProductID = getNextOrderProductId();
                order.productName = product.Name;
                order.userID = userId;
                order.state = 3;
                order.productPrice = product.Price;
                order.imgLink = product.ImgLink;
                order.productMaxAverageTime = product.MaxTime;
                order.productMinAverageTime = product.MinTime;
                order.orderedTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                _orderProducts.Add((int) order.orderProductID,order);
            }
        }

        public void deleteOrderProducts(IEnumerable<long> orderProducts, long userId)
        {
        
            foreach (long orderId in orderProducts)
            {
                _orderProducts.Remove((int)orderId);
            }
        }

        private int getNextUserId() { return ++_userId; }
        private int getNextTableId() { return ++_tableId; }
        private int getNextRestaurantId() { return ++_restaurantId; }
        private int getNextCategoryId() { return ++_categoryId; }
        private int getNextProductId() { return ++_productId; }
        private int getNextOrderProductId() { return ++_orderProductId; }
        private int getNextFavoriteId() { return ++_favoriteId; }

        private void InsertData()
        {
            // Users Table
            User user;
            user = new User
            {
                Id = getNextUserId(),
                Username = "user",
                Email = "user@gmail.com",
                Password = "user",
                Name = "Test User",
                Created = DateTime.Now
            };
            _users.Add(user.Id, user);

            //Tables Table
            Table table;
            for (int i = 0; i < 10; i++)
            {
                table = new Table
                {
                    Id = getNextTableId(),
                    RestaurantID = 1,

                };
                _tables.Add(table.Id, table);
            }

            //Restaurants Table
            Restaurant restaurant;
            restaurant = new Restaurant
            {
                Id = getNextRestaurantId(),
                Name = "TestRestaurant"
            };
            _restaurants.Add(restaurant.Id, restaurant);

            //Categories Table
            Category category;
            category = new Category
            {
                Id = getNextCategoryId(),
                RestaurantId = 1,
                CategoryName = "Carne"
            };
            _categories.Add(category.Id, category);
            category = new Category
            {
                Id = getNextCategoryId(),
                RestaurantId = 1,
                CategoryName = "Peixe"
            };
            _categories.Add(category.Id, category);
            category = new Category
            {
                Id = getNextCategoryId(),
                RestaurantId = 1,
                CategoryName = "Vegetariano"
            };
            _categories.Add(category.Id, category);
            category = new Category
            {
                Id = getNextCategoryId(),
                RestaurantId = 1,
                CategoryName = "Bebidas"
            };
            _categories.Add(category.Id, category);
            category = new Category
            {
                Id = getNextCategoryId(),
                RestaurantId = 1,
                CategoryName = "Entradas"
            };
            _categories.Add(category.Id, category);

            Product product;
            product = new Product
            {
                Id = getNextProductId(),
                Name = "Bifana",
                Price = 3.5f,
                MinTime = 0.5f,
                MaxTime = 1,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1_0zXE1wScxdn0DbOXYKE-CgpM7y1BtFI"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Burger",
                Price = 4.5f,
                MinTime = 10,
                MaxTime = 20,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1c-MFHH_qZew23MctTSD5awnbXInElt9S"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Bitoque",
                Price = 6,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1LQGxf3P06aSjaF1CsdYDb0xPnA2jp5_p"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "PicaPau",
                Price = 7,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Carne",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=147cNPkB0OcP5u4bRthoR6ci7At0CujhA"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Salmão",
                Price = 5.5f,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1SmNbsAumK8EyMUYKMcckzNmqJJpDHO1B"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Cavala",
                Price = 5,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1wLjDQC0r2HDlwEOE7ESL3dQ3rxSOdIfo"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Sardinhas",
                Price = 7,
                MinTime = 15,
                MaxTime = 0,
                CategoryName = "Peixe",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1LIxNKqxd4Pm4BIW6LQD0lyIZKG7-N2jw"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Tofu",
                Price = 6,
                MinTime = 10,
                MaxTime = 0,
                CategoryName = "Vegetariano",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1el9d-UigHTeofLidLGsUdzvgAUcJVF2n"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Salada",
                Price = 3,
                MinTime = 5,
                MaxTime = 0,
                CategoryName = "Vegetariano",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1oVeMz6LFflskxZTCNgP9TWAwkoFhpnyo"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Coca-cola",
                Price = 1.5f,
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Bebidas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1NiqopfKfi1T3jkdmk22o-uEqVyiKD-Je"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Sumol",
                Price = 1.5f,
                MinTime = 0,
                MaxTime = 0,
                CategoryName = "Bebidas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1QZRDXI3wP1fbrnD0nB-75GDj13e-0-iZ"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Queijo",
                Price = 2,
                MinTime = 2,
                MaxTime = 0,
                CategoryName = "Entradas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1ZsxgrHaG2WZGrqoOqE32kDmhQ4XhTLMf"
            };
            _products.Add(product.Id, product);

            product = new Product
            {
                Id = getNextProductId(),
                Name = "Azeitonas",
                Price = 1,
                MinTime = 1,
                MaxTime = 0,
                CategoryName = "Entradas",
                RestaurantId = 1,
                ImgLink = "https://docs.google.com/uc?id=1GJ-RYLa646927CSjglz5YFjtri_LcS13"
            };
            _products.Add(product.Id, product);
       

            
        }

       

        public void deleteOrderProducts(IEnumerable<long> orderProducts)
        {
            throw new NotImplementedException();
        }
        */
    }
}