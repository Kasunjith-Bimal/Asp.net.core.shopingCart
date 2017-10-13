using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.Data.Moke;
using ProjectTest.ViewModel;

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

        public IActionResult List()
        {
            DrinkViewModel drinkviewmodel = new DrinkViewModel();

            drinkviewmodel.Drinks = _drinkRepository.Drinks;
            drinkviewmodel.CurentCategory = "Drink Cateogory";
            
            return View(drinkviewmodel);
        }
       

    }
}
