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
        private readonly ICategory _categoryRepository;
        Drink drinks = new Drink();
        public ShopingCartController(IDrink drinkRepository, IShopingCart shopingCartRepository, ICategory categoryRepository, ShopingCard shopingCart)
        {
            _drinkRepository = drinkRepository;
            _shopingCartRepository = shopingCartRepository;
            _categoryRepository = categoryRepository;
            _shopingCart = shopingCart;
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


        public RedirectToActionResult AddToShopingCart(int drinkid)
        {
            
            drinks = _drinkRepository.Drinks.Where(x=>x.DrinkId==drinkid).ToList().FirstOrDefault();
           //int categoryid= _drinkRepository.Drinks.Where(x => x.DrinkId == drinkid).Select(x => x.CategoryId).FirstOrDefault();
           // drink.Category = _categoryRepository.Categories.Where(x => x.CategoryId == categoryid).FirstOrDefault();
            if (drinks != null)
            {
                _shopingCart.AddCard(drinks, 1);
            }

           return RedirectToAction("Index");
        }


        public RedirectToActionResult ReMoveShopingCart(int drinkid)
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
