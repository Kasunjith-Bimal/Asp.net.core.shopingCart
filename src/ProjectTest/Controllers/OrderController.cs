using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Model;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult CheckOut()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var items = _shoppingCart.getShopingCardItems();
            _shoppingCart.ShoppingCardItems = items;
            if (_shoppingCart.ShoppingCardItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some drinks first");
            }
            if (ModelState.IsValid)
            {
                _order.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutCompleteMessage");
            }
            return View();
        }



        public IActionResult CheckOutCompleteMessage()
        {
            ViewBag.Message = "Complete Checkout Order";
            return View();
        }
    }
}
