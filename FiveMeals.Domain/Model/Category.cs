﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public String CategoryName { get; set; }
    }
}
