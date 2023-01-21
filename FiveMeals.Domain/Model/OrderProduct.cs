using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long orderProductID { get; set; }
        public long userID { get; set; }
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
        public int maxSteps { get; set;}

    }
}
