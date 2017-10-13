using ProjectTest.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Data.Model;

namespace ProjectTest.Data.Moke
{
    public class MokeCategoryRepository : ICategory
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryId=1,CategoryName="Cat1",Description="cat1des" },
                    new Category {CategoryId=2,CategoryName="Cat2",Description="cat2des" },
                    new Category {CategoryId=3,CategoryName="Cat3",Description="cat3des" },

                };
            }
        }
    }
}
