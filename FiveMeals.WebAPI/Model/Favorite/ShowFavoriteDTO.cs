namespace FiveMeals.WebAPI.Model.Favorite
{
    public class ShowFavoriteDTO
    {
        public long productID { get; set; }
        public String userEmail { get; set; }
        public long restaurantID { get; set; }
        public String productName { get; set; }
        public float productPrice { get; set; }
        public String productImage { get; set; }
    }
}
