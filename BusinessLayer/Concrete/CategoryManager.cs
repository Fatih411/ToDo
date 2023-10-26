using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        DataAccessLayer.Abstract.ICategoryDal _category;

        public CategoryManager(DataAccessLayer.Abstract.ICategoryDal category)
        {
            _category = category;
        }

        public Category GetById(int id)
        {
           return _category.GetById(id);
        }

        public void TDelete(EntityLayer.Concrete.Category t)
        {
            _category.Delete(t);
        }

        public List<EntityLayer.Concrete.Category> TGetAll()
        {
            return _category.GetAll();
        }

        public void TInsert(EntityLayer.Concrete.Category t)
        {
            _category.Insert(t);
        }

        public void TUpdate(EntityLayer.Concrete.Category t)
        {
            _category.Update(t);
        }
    }
}
