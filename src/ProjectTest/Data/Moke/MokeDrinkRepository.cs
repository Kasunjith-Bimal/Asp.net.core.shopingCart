using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Data.Model;

namespace ProjectTest.Data.Moke
{
    public class MokeDrinkRepository : IDrink
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategory _categoryrepository = new MokeCategoryRepository();
        public IEnumerable<Drink> Drinks
        {
            get
            {
                return new List<Drink>
                {
                    new Drink {DrinkId=1,ShortDescription="sh1",Price=12.55M,LongtDescription="shlong1",Name="na1",ImageUrl="../Images/a.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=true,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh2",Price=12.25M,LongtDescription="shlong2",Name="na2",ImageUrl="../Images/b.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh3",Price=12.25M,LongtDescription="shlong2",Name="na3",ImageUrl="../Images/i.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh4",Price=12.25M,LongtDescription="shlong2",Name="na4",ImageUrl="../Images/d.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh5",Price=12.25M,LongtDescription="shlong2",Name="n52",ImageUrl="../Images/h.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh6",Price=12.25M,LongtDescription="shlong2",Name="na6",ImageUrl="../Images/f.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh7",Price=12.25M,LongtDescription="shlong2",Name="na7",ImageUrl="../Images/h.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },
                    new Drink {DrinkId=1,ShortDescription="sh8",Price=12.25M,LongtDescription="shlong2",Name="na8",ImageUrl="../Images/i.jpg",InStock=50,ImageThumbnealUrl="../Images/a.jpg",IsPrefeedDrink=false,Category=_categoryrepository.Categories.First() },


                };

            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Drink> PreferredDrinks
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Drink GetDrinkById(int drinkId)
        {
            throw new NotImplementedException();
        }
    }
}
