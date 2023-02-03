using System.Runtime.InteropServices;

namespace FiveMeals.WebAPI.Model.OrderProduct
{
    public class OrderProductShowDTO
    {
        
        public long orderProductID { get; set; }
        public long orderId { get; set; }
        public String userEmail { get; set; }
        public DateTime orderedTime { get; set; }

        public long productID { get; set; }
        public String productName { get; set; }
        public float productPrice { get; set; }
        public float productMinAverageTime { get; set; }
        public float productMaxAverageTime { get; set; }
        public String imgLink { get; set; }
        public int stepsMade { get; set; }
        public int maxSteps { get; set; }
        public Boolean paid { get; set; }
        public Boolean delivered { get; set; }

    }
}
