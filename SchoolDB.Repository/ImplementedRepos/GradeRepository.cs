using SchoolDB.Model.Models;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.ImplementedRepos
{
    public class GradeRepository : AbstractRepository<Grade>, IRepository<Grade>
    {
        public GradeRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Grade Read(int id)
        {
            return ctx.Grades.FirstOrDefault(g => g.Id == id);
        }

        public override void Update(Grade item)
        {
            var old = Read(item.Id);
            foreach (var x in old.GetType().GetProperties())
            {
                if (x.GetAccessors().FirstOrDefault(t=> t.IsVirtual) == null)
                {
                    x.SetValue(old, x.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
