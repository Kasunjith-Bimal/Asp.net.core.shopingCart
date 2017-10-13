using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectTest.Data.Model
{
    public class ShopingCard
    {
        private readonly AppDbContext _appDbContext;
        public ShopingCard(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShopingCardId { get; set; }

        public List<ShopingCardItem> ShoppingCardItems { get; set; }


        public static ShopingCard GetCart(IServiceProvider servise)
        {
            ISession session = servise.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = servise.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShopingCard(context) { ShopingCardId = cartId };
        }

        public void AddCard(Drink drink,int amount)
        {
            var shopingCardItem = _appDbContext.ShopingCardItems.Where(x => x.Drink.DrinkId == drink.DrinkId && x.ShopingCardId == ShopingCardId).FirstOrDefault();

            
            if (shopingCardItem == null)
            {


                shopingCardItem.Amount = 1;
                shopingCardItem.Drink = drink;
                shopingCardItem.ShopingCardId = ShopingCardId;

                _appDbContext.ShopingCardItems.Add(shopingCardItem);

              

            }
            else
            {
                shopingCardItem.Amount++;


            }
            _appDbContext.SaveChanges();
        }


        public int RemoveFromCart(Drink drink)
        {
            var shopingCardItem = _appDbContext.ShopingCardItems.Where(x => x.Drink.DrinkId == drink.DrinkId && x.ShopingCardId == ShopingCardId).FirstOrDefault();

            var localAmount = 0;

            if (shopingCardItem != null)
            {
                if (shopingCardItem.Amount > 1)
                {
                    shopingCardItem.Amount--;
                    localAmount = shopingCardItem.Amount;

                }
                else
                {
                    _appDbContext.ShopingCardItems.Remove(shopingCardItem);
                }
            

            }
            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShopingCardItem> getShopingCardItems()
        {

            List<ShopingCardItem> ShopingCardItemList = _appDbContext.ShopingCardItems.Where(x => x.ShopingCardId == ShopingCardId).Include(x => x.Drink).ToList();

            return ShopingCardItemList;

        }

        public void ClearCart()
        {
            var shopingCardItem = _appDbContext.ShopingCardItems.Where(x =>x.ShopingCardId == ShopingCardId);
            _appDbContext.ShopingCardItems.RemoveRange(shopingCardItem);
            _appDbContext.SaveChanges();


        }

        public decimal GetShopingCardTotal()
        {
            var shopingCardItemTotal = _appDbContext.ShopingCardItems.Where(x => x.ShopingCardId == ShopingCardId).Select(x=>x.Drink.Price * x.Amount).Sum();
            return shopingCardItemTotal;
        }
    }
}
