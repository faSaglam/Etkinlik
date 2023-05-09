using Business.Abstract;
using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public ICollection<Category> GetAll()
        {
           return _categoryDal.GetAll();
        }

        public Category GetSingleCategory(int id)
        {
          return _categoryDal.Get(filter:c=>c.CategoryID == id);
        }

        public Category GetSingleCategory(string name)
        {
            return _categoryDal.Get(filter:c=>c.CategoryName == name);
        }

        public void Update(Category category)
        {
           _categoryDal.Update(category);
        }
    }
}
