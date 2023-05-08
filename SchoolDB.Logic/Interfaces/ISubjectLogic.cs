using SchoolDB.Model.Models;
using System.Linq;

namespace SchoolDB.Logic.Interfaces
{
    public interface ISubjectLogic
    {
        void Create(Subject item);
        void Delete(int id);
        Subject Read(int id);
        IQueryable<Subject> ReadAll();
        void Update(Subject item);
    }
}