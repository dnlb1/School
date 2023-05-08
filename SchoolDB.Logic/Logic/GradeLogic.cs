using Microsoft.Extensions.Caching.Memory;
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
    public class GradeLogic : IGradeLogic
    {
        IRepository<Grade> _Logic;

        public GradeLogic(IRepository<Grade> logic)
        {
            _Logic = logic;
        }

        public void Create(Grade item)
        {
            if (item.Value > 0 && item.Value < 6)
            {
                _Logic.Create(item);
            }
            else
            {
                //Most nem kezelek exceptiont.
                //Egyszerűen nem lesz létrehozva.
            }
        }

        public void Delete(int id)
        {
            _Logic.Delete(id);
        }

        public Grade Read(int id)
        {
            return _Logic.Read(id);
        }

        public IQueryable<Grade> ReadAll()
        {
            return _Logic.ReadAll();
        }

        public void Update(Grade item)
        {
            _Logic.Update(item);
        }

        public IEnumerable<AvgGradeSubject> StudentSAvg(Student s, int month)
        {
            var x = _Logic.ReadAll().ToList().Where(t => DateTime.Parse(t.Time.ToString()).Month == month && t.StundetId==s.Id).
                GroupBy(t=>t.Subject.Name).Select(t=> new AvgGradeSubject()
                {
                    Avg=(double)Math.Round((double)t.Average(z=>z.Value),2),
                    SubjectID = t.Key,
                    
                });
            return x;
        }
    }
}
