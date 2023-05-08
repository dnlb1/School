using SchoolDB.Model.Models;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.ImplementedRepos
{
    public class ClassRepository : AbstractRepository<Class>, IRepository<Class>
    {
        public ClassRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Class Read(int id)
        {
            return this.ctx.Classes.FirstOrDefault(c => c.Id == id);
        }

        public override void Update(Class item)
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
