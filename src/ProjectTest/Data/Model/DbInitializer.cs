using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.Model
{
    public class DbInitializer
    {
        public static void seed(IApplicationBuilder applicationbuilder)
        {

            AppDbContext context = applicationbuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(x => x.Value));

            }

            if (!context.Drinks.Any())
            {
                context.AddRange(
                    new Drink { ShortDescription = "sh1", Price = 12.55M, LongtDescription = "shlong1", Name = "na1", ImageUrl = "../Images/a.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = true, Category = Categories["Cat1"] },
                    new Drink { ShortDescription = "sh2", Price = 12.25M, LongtDescription = "shlong2", Name = "na2", ImageUrl = "../Images/b.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = false, Category = Categories["Cat2"] },
                    new Drink { ShortDescription = "sh3", Price = 12.25M, LongtDescription = "shlong2", Name = "na3", ImageUrl = "../Images/i.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = false, Category = Categories["Cat3"] },
                    new Drink { ShortDescription = "sh4", Price = 12.25M, LongtDescription = "shlong2", Name = "na4", ImageUrl = "../Images/d.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = true, Category = Categories["Cat2"] },
                    new Drink { ShortDescription = "sh5", Price = 12.25M, LongtDescription = "shlong2", Name = "n52", ImageUrl = "../Images/h.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = false, Category = Categories["Cat3"] },
                    new Drink { ShortDescription = "sh6", Price = 12.25M, LongtDescription = "shlong2", Name = "na6", ImageUrl = "../Images/f.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = false, Category = Categories["Cat1"] },
                    new Drink { ShortDescription = "sh7", Price = 12.25M, LongtDescription = "shlong2", Name = "na7", ImageUrl = "../Images/h.jpg", InStock = 50, ImageThumbnealUrl = "../Images/a.jpg", IsPrefeedDrink = false, Category = Categories["Cat2"] }



                    );

            }

            context.SaveChanges();

        }


        public static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> Categories
        {

            get
            {
                if (categories == null)
                {
                    var categorylist = new Category[]
                    {
                    new Category {CategoryName="Cat1",Description="cat1des" },
                    new Category {CategoryName="Cat2",Description="cat2des" },
                    new Category {CategoryName="Cat3",Description="cat3des" },
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category item in categorylist)
                    {
                        categories.Add(item.CategoryName, item);
                    }
                }
                return categories;

            }

        }
    }
}
