using Microsoft.EntityFrameworkCore;
using ProjectTest.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopingCardItem> ShopingCardItems { get; set; }


        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
