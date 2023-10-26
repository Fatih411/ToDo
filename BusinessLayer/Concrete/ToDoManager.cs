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
    public class ToDoManager : ITodoService
    {
        readonly IToDoDal _toDo;

        public ToDoManager(IToDoDal toDo)
        {
            _toDo = toDo;
        }

        public ToDo GetById(Guid id)
        {
           return _toDo.GetById(id);
        }

        public void TDelete(EntityLayer.Concrete.ToDo t)
        {
            _toDo.Delete(t);
        }

        public List<EntityLayer.Concrete.ToDo> TGetAll()
        {
            return _toDo.GetAll();
        }

        public void TInsert(EntityLayer.Concrete.ToDo t)
        
        {
            _toDo.Insert(t);
        }

        public void TUpdate(EntityLayer.Concrete.ToDo t)
        {
            _toDo.Update(t);
        }

      
    }
}
