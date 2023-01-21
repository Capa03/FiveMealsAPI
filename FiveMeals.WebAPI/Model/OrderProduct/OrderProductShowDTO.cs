using System.Runtime.InteropServices;

namespace FiveMeals.WebAPI.Model.OrderProduct
{
    public class OrderProductShowDTO
    {
        
        public long orderProductID { get; set; }
        public long userId { get; set; }
        public long tableID { get; set; }
        public int state { get; set; }
        public long orderedTime { get; set; }

        public long productID { get; set; }
        public String productName { get; set; }
        public float productPrice { get; set; }
        public float productMinAverageTime { get; set; }
        public float productMaxAverageTime { get; set; }
        public String imgLink { get; set; }
        public int stepsMade { get; set; }
     
    }
}
