using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class CategoryWithProducts
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public String CategoryName { get; set; }
        public List<Product> products { get; set; }

    }
}
