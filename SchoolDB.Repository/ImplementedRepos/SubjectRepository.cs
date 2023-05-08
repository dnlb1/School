using SchoolDB.Model.Models;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.ImplementedRepos
{
    public class SubjectRepository : AbstractRepository<Subject>, IRepository<Subject>
    {
        public SubjectRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Subject Read(int id)
        {
            return ctx.Subjects.FirstOrDefault(t=>t.Id == id);  
        }

        public override void Update(Subject item)
        {
            var old = Read(item.Id);
            foreach (var x in old.GetType().GetProperties())
            {
                if (x.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    x.SetValue(old, x.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
