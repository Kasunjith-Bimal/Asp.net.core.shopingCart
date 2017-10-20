using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Model;
using ProjectTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Components
{
    public class ShopingCardSummeryViewComponents : ViewComponent
    {
        private readonly ShopingCard _shopingCard;
        public ShopingCardSummeryViewComponents(ShopingCard shopingCard)
        {
            _shopingCard = shopingCard;
        }

        public IViewComponentResult Invoke()
        {
            List<ShopingCardItem> listdumy = new List<ShopingCardItem>();
            ShopingCardItem shop = new ShopingCardItem();
            listdumy.Add(shop);
            ShopingCardItem shop1 = new ShopingCardItem();
            listdumy.Add(shop1);

            //var shoppingcarditem = _shopingCard.getShopingCardItems();
            var shoppingcarditem = listdumy;
            _shopingCard.ShoppingCardItems = shoppingcarditem;

            ShopingCartViewModel shopingCardViewModel = new ShopingCartViewModel();

            shopingCardViewModel.ShopingCard = _shopingCard;
            //shopingCardViewModel.ShopingCardTotal = _shopingCard.GetShopingCardTotal();
            shopingCardViewModel.ShopingCardTotal = 0;
            return View(shopingCardViewModel);
        }

    }
}
