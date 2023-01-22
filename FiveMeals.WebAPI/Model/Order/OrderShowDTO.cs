namespace FiveMeals.WebAPI.Model.Order
{
    public class OrderShowDTO
    {
        public long Id { get; set; }
        public long tableId { get; set; }
        public DateTime Created { get; set; }
        public Boolean open { get; set; }
    }
}
