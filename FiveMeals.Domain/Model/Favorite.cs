using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class Favorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long productID {get;set;}
        public long userID {get;set;}
        public long restaurantID {get;set;}
        public String productName {get;set;}
        public float productPrice  {get;set;}
        public String productImage {get;set;}
    }
}
