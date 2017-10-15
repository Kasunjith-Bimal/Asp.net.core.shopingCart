using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using ProjectTest.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrink _drinkRepository;
        // GET: /<controller>/
        public HomeController(IDrink drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public IActionResult Index()
        {
            HomeViewModel homeviewmodel = new HomeViewModel();
            homeviewmodel.PreferredDrinks = _drinkRepository.PreferredDrinks;
            return View(homeviewmodel);
        }
    }
}
