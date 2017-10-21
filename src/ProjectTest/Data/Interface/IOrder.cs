using ProjectTest.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.Interface
{
    public interface IOrder
    {
        void CreateOrder(Order order);
    }
}
