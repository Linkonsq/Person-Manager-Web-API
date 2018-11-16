using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSInterface;
using PMSEntity;
using PMSData;
using System.Data.Entity;

namespace PMSRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private PMSDBContext context = new PMSDBContext();

        public PMSDBContext Context
        {
            get { return this.context; }
        }

        public List<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            return this.context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            return this.context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            return this.context.SaveChanges();
        }
    }
}
