using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Model;
using ProjectTest.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IDrink _drinkRepository;
        private readonly IShopingCart _shopingCartRepository;
        private readonly ShopingCard _shopingCart;

        public ShopingCartController(IDrink drinkRepository, IShopingCart shopingCartRepository)
        {
            _drinkRepository = drinkRepository;
            _shopingCartRepository = shopingCartRepository;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ShopingCardItem> shopingCartItems = new List<ShopingCardItem>();
            shopingCartItems = _shopingCart.getShopingCardItems();
            _shopingCart.ShoppingCardItems = shopingCartItems;

            ShopingCartViewModel shopingcardviewmodel = new ShopingCartViewModel();

            shopingcardviewmodel.ShopingCard = _shopingCart;
            shopingcardviewmodel.ShopingCardTotal = _shopingCart.GetShopingCardTotal();

            return View(shopingcardviewmodel);
        }


        public IActionResult AddToShopingCart(int drinkid)
        {
            var selectdrink = _drinkRepository.Drinks.Where(X => X.DrinkId == drinkid).FirstOrDefault();

            if (selectdrink != null)
            {
                _shopingCart.AddCard(selectdrink, 1);
            }

           return RedirectToAction("Index");
        }


        public IActionResult ReMoveShopingCart(int drinkid)
        {
            var selectdrink = _drinkRepository.Drinks.Where(X => X.DrinkId == drinkid).FirstOrDefault();

            if (selectdrink != null)
            {
                _shopingCart.RemoveFromCart(selectdrink);
            }

            return RedirectToAction("Index");
        }
    }
}
