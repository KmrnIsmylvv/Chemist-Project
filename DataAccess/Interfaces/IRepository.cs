using Entities.Interfaces;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T:IEntity
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        List<T> GetAll(Predicate<T> filter=null);
        T Get(Predicate<T> filter=null);
    }
}
