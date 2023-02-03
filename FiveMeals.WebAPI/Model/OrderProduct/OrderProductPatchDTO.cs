namespace FiveMeals.WebAPI.Model.OrderProduct
{
    public class OrderProductPatchDTO
    {
        public long orderId { get; set; }
        public long orderProductID { get; set; }
        public int stepsMade { get; set; }
        public Boolean paid { get; set; }
        public Boolean delivered { get; set; }
    }
}
