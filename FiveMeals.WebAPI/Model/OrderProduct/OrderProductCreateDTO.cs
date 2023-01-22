namespace FiveMeals.WebAPI.Model.OrderProduct
{
    public class OrderProductCreateDTO
    {
        public String userEmail { get; set; }
        public long orderId { get; set; }
        public long tableID { get; set; }
        public long productID { get; set; }


    }
}
