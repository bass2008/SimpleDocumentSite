using AlphaLeasing.Common.Entity;
using AlphaLeasing.DataAccess.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace AlphaLeasing.DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : ElementWithId
    {
        protected ISession _session;
        
        public GenericRepository(ISession session)
        {
            _session = session; 
        }
        
        public void SaveOrUpdate(T item)
        {
            _session.SaveOrUpdate(item);
        }
        
        public List<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }
        
        public void Dispose()
        {
            _session.Dispose();
        }
    }
}