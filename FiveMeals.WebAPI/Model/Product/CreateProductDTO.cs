namespace FiveMeals.WebAPI.Model.Product
{
    public class CreateProductDTO
    {
        public int RestaurantId { get; set; }
        public string CategoryName { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImgLink { get; set; }
        public double MinTime { get; set; }
        public double MaxTime { get; set; }
    }
}
