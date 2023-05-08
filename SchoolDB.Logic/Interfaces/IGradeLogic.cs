using SchoolDB.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDB.Logic.Interfaces
{
    public interface IGradeLogic
    {
        void Create(Grade item);
        void Delete(int id);
        Grade Read(int id);
        IQueryable<Grade> ReadAll();
        void Update(Grade item);
        IEnumerable<AvgGradeSubject> StudentSAvg(Student s, int month);
    }
}