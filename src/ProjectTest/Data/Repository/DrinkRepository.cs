using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Data.Model;

namespace ProjectTest.Data.Repository
{
    public class DrinkRepository : IDrink
    {
        private readonly AppDbContext _appDbContext;

        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        
        

        public IEnumerable<Drink> GetAllNonAlcoholicDrinks
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(x=>x.IsPrefeedDrink==true).ToList();


        public Drink GetDrinkById(int drinkId) => _appDbContext.Drinks.Where(x => x.DrinkId == drinkId).FirstOrDefault();
       
    }
}
