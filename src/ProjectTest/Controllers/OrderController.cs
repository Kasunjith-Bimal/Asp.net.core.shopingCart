using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;

        private readonly ShopingCard _shoppingCart;

        public OrderController(IOrder order, ShopingCard shoppingCar)
        {
            _order = order;
            _shoppingCart = shoppingCar;
        }
        // GET: /<controller>/
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
