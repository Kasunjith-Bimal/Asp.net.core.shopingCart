using ProjectTest.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.ViewModel
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }

        public string CurentCategory { get; set; }
    }
}
