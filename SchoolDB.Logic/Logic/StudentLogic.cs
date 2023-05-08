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
    public class StudentLogic : IStudentLogic
    {
        IRepository<Student> _Logic;

        public StudentLogic(IRepository<Student> logic)
        {
            _Logic = logic;
        }

        public void Create(Student item)
        {
            _Logic.Create(item);
        }

        public void Delete(int id)
        {
            _Logic.Delete(id);
        }

        public Student Read(int id)
        {
            return _Logic.Read(id);
        }

        public IQueryable<Student> ReadAll()
        {
            return _Logic.ReadAll();
        }

        public void Update(Student item)
        {
            _Logic.Update(item);
        }
    }
}
