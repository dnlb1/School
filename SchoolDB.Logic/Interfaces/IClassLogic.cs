using SchoolDB.Model.Models;
using System.Linq;

namespace SchoolDB.Logic.Interfaces
{
    public interface IClassLogic
    {
        void Create(Class item);
        void Delete(int id);
        Class Read(int id);
        IQueryable<Class> ReadAll();
        void Update(Class item);
    }
}