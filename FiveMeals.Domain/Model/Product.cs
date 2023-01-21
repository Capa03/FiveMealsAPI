using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImgLink { get; set; }
        public float MinTime { get; set; }
        public float MaxTime { get; set; }

        public int RestaurantId { get; set; }
        public string CategoryName { get; set; }

        public int maxSteps { get; set; }

    }
}
