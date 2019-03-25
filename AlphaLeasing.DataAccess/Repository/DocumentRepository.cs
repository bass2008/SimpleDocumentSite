using AlphaLeasing.Common.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaLeasing.DataAccess.Repository
{
    public class DocumentRepository : IDocumentRepository, IDisposable
    {
        protected ISession _session;
        
        public DocumentRepository(ISession session)
        {
            _session = session; 
        }
        
        public void Add(Document item)
        {
            _session.CreateSQLQuery($"exec CreateDoc '{item.Name}','{item.Date}', {item.UserId} ");
        }
        
        public Document Get(int id)
        {
            return _session.Query<Document>().FirstOrDefault(x => x.Id == id);
        }

        public Document Get(Func<Document, bool> func)
        {
            return _session.Query<Document>().FirstOrDefault(func);
        }

        public List<Document> GetAll()
        {
            return _session.Query<Document>().ToList();
        }
        
        public void Dispose()
        {
            _session.Dispose();
        }
    }
}