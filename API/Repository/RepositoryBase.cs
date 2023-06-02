using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DataBase;
using API.Interface;
using Microsoft.EntityFrameworkCore;


namespace API.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyContext myContext;

        public RepositoryBase(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public IQueryable<T> FindAll() => myContext.Set<T>().AsNoTracking();
         public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
            myContext.Set<T>().Where(expression).AsNoTracking();
         public void Create(T entity) => myContext.Set<T>().Add(entity);
         public void Update(T entity) => myContext.Set<T>().Update(entity);
         public void Delete(T entity) => myContext.Set<T>().Remove(entity);
    }
}