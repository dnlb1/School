using SchoolDB.Logic.Interfaces;
using SchoolDB.Model.Models;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Logic.Logic
{
    public class ClassLogic : IClassLogic
    {
        IRepository<Class> _Logic;

        public ClassLogic(IRepository<Class> logic)
        {
            _Logic = logic;
        }

        public void Create(Class item)
        {
            _Logic.Create(item);
        }

        public void Delete(int id)
        {
            _Logic.Delete(id);
        }

        public Class Read(int id)
        {
            return _Logic.Read(id);
        }

        public IQueryable<Class> ReadAll()
        {
            return _Logic.ReadAll();
        }

        public void Update(Class item)
        {
            _Logic.Update(item);
        }
    }
}
