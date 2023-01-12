using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveMeals.Domain.Model
{
    public class Login
    {
        public String login { get; set; }
        public String password { get; set; }
        public Boolean match { get; set; }
    }
}
