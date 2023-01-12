using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class Favorite
    {

        public long productID {get;set;}
        public long userID {get;set;}
        public long restaurantID {get;set;}
        public String productName {get;set;}
        public float productPrice  {get;set;}
        public String productImage {get;set;}
    }
}
