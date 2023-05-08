using SchoolDB.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected SchoolDbContext ctx;

        protected AbstractRepository(SchoolDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            this.ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            this.ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return this.ctx.Set<T>();
        }
        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
