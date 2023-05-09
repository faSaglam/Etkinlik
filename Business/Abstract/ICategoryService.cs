using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> GetAll();
        Category GetSingleCategory(int id);
        Category GetSingleCategory(string id);

        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
