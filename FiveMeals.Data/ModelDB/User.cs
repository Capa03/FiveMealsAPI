using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Data.ModelDB
{
    public class User
    {
        
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
