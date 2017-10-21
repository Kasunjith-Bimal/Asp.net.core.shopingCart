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

       
        public ViewResult List(string category)
        {
            DrinkViewModel drinkviewmodel = new DrinkViewModel();
            drinkviewmodel.Drinks = _drinkRepository.Drinks;
            int categoryid=0;
            
            if (string.IsNullOrEmpty(category))
            {
                
                drinkviewmodel.CurentCategory = "All Drink Cateogory";

            }
            else
            {
                if(category == "Alcoholic")
                {
                    categoryid = _categoryRepository.Categories.Where(x => x.CategoryName == category).Select(x => x.CategoryId).FirstOrDefault();
                    drinkviewmodel.Drinks = drinkviewmodel.Drinks.Where(x => x.CategoryId == categoryid).ToList();
                    drinkviewmodel.CurentCategory = category;
                }
                else if(category == "NonAlcoholic")
                {
                    categoryid = _categoryRepository.Categories.Where(x => x.CategoryName == category).Select(x => x.CategoryId).FirstOrDefault();
                    drinkviewmodel.Drinks = drinkviewmodel.Drinks.Where(x => x.CategoryId == categoryid).ToList();
                    drinkviewmodel.CurentCategory = category;
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
