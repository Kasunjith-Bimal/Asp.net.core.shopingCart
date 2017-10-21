using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Data.Model;

namespace ProjectTest.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContext _appDbContext;

        private readonly ShopingCard _shoppingCart;
        public OrderRepository(AppDbContext appDbContext, ShopingCard shoppingCart)
        {
            _appDbContext = appDbContext;

            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shopingCardItem = _shoppingCart.ShoppingCardItems;

            foreach (var item in shopingCardItem)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.Amount = item.Amount;
                orderDetail.DrinkId = item.Drink.DrinkId;
                orderDetail.OrderId = order.OrderId;
                orderDetail.Price = item.Drink.Price;

                _appDbContext.OrderDetails.Add(orderDetail);

            }  
            _appDbContext.SaveChanges();
        }
    }
}
