using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Components
{
    public class CategoryMenuViewComponents : ViewComponent
    {
        private readonly ICategory _categoryrepository;
        public CategoryMenuViewComponents(ICategory categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }
        public IViewComponentResult Invoke()
        {
            var category = _categoryrepository.Categories.OrderBy(X => X.CategoryName);

            return View(category);
        }
    }
}