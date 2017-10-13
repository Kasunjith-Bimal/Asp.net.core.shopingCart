using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.Model
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongtDescription { get; set; }
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnealUrl { get; set; }

        public bool IsPrefeedDrink { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
