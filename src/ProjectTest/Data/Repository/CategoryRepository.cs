using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Data.Model;

namespace ProjectTest.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories.ToList();
        
    }
}
