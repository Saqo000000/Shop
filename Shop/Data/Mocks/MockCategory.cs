using Shop.Data.Interfaces;
using Shop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category {categoryName="electric", desc="modern type of mashine" },
            new Category {categoryName="classic", desc="cars with inside fireing engine" }
        }; 

    }
}
