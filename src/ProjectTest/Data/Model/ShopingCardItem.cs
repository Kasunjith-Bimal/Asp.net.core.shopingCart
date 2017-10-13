using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.Model
{
    public class ShopingCardItem
    {
        public int ShopingCardItemId { get; set; }

        public Drink Drink { get; set; }

        public int Amount { get; set; }

        public string ShopingCardId { get; set; }
    }
}
