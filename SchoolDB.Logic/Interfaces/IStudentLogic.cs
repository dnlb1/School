using SchoolDB.Model.Models;
using System.Linq;

namespace SchoolDB.Logic.Interfaces
{
    public interface IStudentLogic
    {
        void Create(Student item);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student item);
    }
}