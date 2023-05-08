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
    public class SubjectLogic : ISubjectLogic
    {
        IRepository<Subject> _Logic;

        public SubjectLogic(IRepository<Subject> logic)
        {
            _Logic = logic;
        }

        public void Create(Subject item)
        {
            _Logic.Create(item);
        }

        public void Delete(int id)
        {
            _Logic.Delete(id);
        }

        public Subject Read(int id)
        {
            return _Logic.Read(id);
        }

        public IQueryable<Subject> ReadAll()
        {
            return _Logic.ReadAll();
        }

        public void Update(Subject item)
        {
            _Logic.Update(item);
        }
    }
}
