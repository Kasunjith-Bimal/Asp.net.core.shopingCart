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

            int orderid =_appDbContext.OrderDetails.Select(x => x.OrderId).Max();
            decimal tottal =_appDbContext.OrderDetails.Where(x =>(decimal) x.OrderId == orderid).Sum(x => x.Price * x.Amount);
            string totalorder = Convert.ToString(tottal);
            int Ordersid = _appDbContext.Orders.Select(x => x.OrderId).Max();
            Order Ordersdata = _appDbContext.Orders.Where(x => x.OrderId == Ordersid).FirstOrDefault();
            Ordersdata.OrderTotal = totalorder;
            UpdateOrderTotalPrice(Ordersdata);
            _appDbContext.Orders.Update(Ordersdata);
            _appDbContext.SaveChanges();
          

        }

        public void UpdateOrderTotalPrice(Order order)
        {
           
        }
    }
}
