using Araba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.BLL.Repository
{
  public  class RepositoryBase<T,ID> where T:class
    {
        protected internal static ArabaContext dbContext;

        public List<T> GetAll()
        {
            dbContext = new ArabaContext();
            return dbContext.Set<T>().ToList();
        }
        public T GetByID(ID id)
        {
            dbContext = new ArabaContext();
            return dbContext.Set<T>().Find(id);
        }
        public virtual int Insert(T entity)
        {
            try
            {
                dbContext = dbContext ?? new ArabaContext();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new ArabaContext();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Update()
        {
            try
            {
                dbContext = dbContext ?? new ArabaContext();
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
