﻿using FiveMeals.Domain.Model;
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
        
        public IEnumerable<Category>? GetCategoriesFromRestaurant(int restaurantId);
        public IEnumerable<Category>? GetAllCategories();
        public void CreateCategory(Category category);

        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsFromCategoryId(int categoryId);
        public void CreateProduct(Product productIn);
        public IEnumerable<CategoryWithProducts> GetCategoriesWithProductsFromRestaurant(int restaurantId);
       
        public IEnumerable<OrderProduct> getOrderProducts(long orderId);
        public void insertOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void updateOrderProducts(IEnumerable<OrderProduct> orderProducts);
        public void deleteOrderProducts(IEnumerable<long> orderProducts);

        public IEnumerable<Favorite> GetFavorites(long userId);
        public void insertFavorite(IEnumerable<Favorite> favorites, long userId);
        public void deleteFavorite(long favorites,long userId);

        public void insertOrder(Order order);
        public Order? GetOrder(Order order);
        public void closeOrder(long orderId);
    }
}
