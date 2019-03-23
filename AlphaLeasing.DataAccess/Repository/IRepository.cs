using AlphaLeasing.Common.Entity;
using System;
using System.Collections.Generic;

namespace AlphaLeasing.DataAccess.Repository
{
    public interface IRepository<T> : IDisposable where T : ElementWithId
    {
        //T Get(int id, bool asNoTracking = false);
        //
        //T Get(Expression<Func<T, bool>> where);
        
        //T Get<TProperty>(Expression<Func<T, bool>> where, Expression<Func<T, TProperty>>[] childSelector);
        //
        List<T> GetAll();
        //
        //T[] GetAll(Expression<Func<T, bool>> where);
        //
        void SaveOrUpdate(T item);
        //
        //void Delete(T item);
        //
        //void Delete(int id);
    }
}