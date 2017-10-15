using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Moke;
using ProjectTest.ViewModel;
using ProjectTest.Data.Model;

namespace ProjectTest.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrink _drinkRepository;
        private readonly ICategory _categoryRepository;

       
        public DrinkController(ICategory categoryRepository, IDrink drinkRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;

        }

        public IActionResult List(string categoryName)
        {
            DrinkViewModel drinkviewmodel = new DrinkViewModel();
            drinkviewmodel.Drinks = _drinkRepository.Drinks;
            if (string.IsNullOrEmpty(categoryName))
            {
                
                drinkviewmodel.CurentCategory = "Drink Cateogory";

            }
            else
            {
                if(categoryName== "Alcoholic")
                {
                    drinkviewmodel.Drinks = drinkviewmodel.Drinks.Where(x => x.Category.CategoryName == "Alcoholic").ToList();
                }else if(categoryName == "NonAlcoholic")
                {
                    drinkviewmodel.Drinks = drinkviewmodel.Drinks.Where(x => x.Category.CategoryName == "NonAlcoholic").ToList();
                }

            }
            
            
            return View(drinkviewmodel);
        }
       
        public IActionResult Details(int drinkid)
        {

            Drink Drinkobj = _drinkRepository.Drinks.Where(x => x.DrinkId == drinkid).FirstOrDefault();

            return View(Drinkobj);
          
        }
    }
}
