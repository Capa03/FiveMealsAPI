using AutoMapper;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.Favorite;
using FiveMeals.WebAPI.Model.Login;
using FiveMeals.WebAPI.Model.Order;
using FiveMeals.WebAPI.Model.OrderProduct;
using FiveMeals.WebAPI.Model.Product;
using FiveMeals.WebAPI.Model.Restaurant;
using FiveMeals.WebAPI.Model.RestaurantTerminal;
using FiveMeals.WebAPI.Model.Table;
using FiveMeals.WebAPI.Model.User;

namespace FiveMeals.WebAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<User, ShowUserDTO>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<Table, ShowTableDTO>();
            CreateMap<CreateTableDTO, Table>();

            CreateMap<Restaurant, ShowRestaurantDTO>();
            CreateMap<CreateRestaurantDTO, Restaurant>();

            CreateMap<Category, ShowCategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();

            CreateMap<Product, ShowProductDTO>();
            CreateMap<CreateProductDTO, Product>();

            CreateMap<Login, ShowLoginDTO>();
            CreateMap<CreateLoginDTO, Login>();

            CreateMap<OrderProduct, OrderProductShowDTO>();
            CreateMap<OrderProductPatchDTO, OrderProduct>();
            CreateMap<OrderProductCreateDTO, OrderProduct>();

            CreateMap<Favorite, ShowFavoriteDTO>();
            CreateMap<CreateFavoriteDTO,Favorite>();

            CreateMap<Order, OrderShowDTO>();
            CreateMap<OrderCreateDTO,Order>();

            CreateMap<CreateRestaurantTerminalDTO, RestaurantTerminal>();

        }
    }
}
