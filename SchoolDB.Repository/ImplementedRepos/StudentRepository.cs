using SchoolDB.Model.Models;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.ImplementedRepos
{
    public class StudentRepository : AbstractRepository<Student>, IRepository<Student>
    {
        public StudentRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Student Read(int id)
        {
            return ctx.Students.FirstOrDefault(s => s.Id == id);
        }

        public override void Update(Student item)
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
