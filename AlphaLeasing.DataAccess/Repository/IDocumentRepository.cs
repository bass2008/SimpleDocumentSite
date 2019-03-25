using AlphaLeasing.Common.Models;
using System;
using System.Collections.Generic;

namespace AlphaLeasing.DataAccess.Repository
{
    public interface IDocumentRepository
    {
        void Add(Document item);

        Document Get(int id);

        Document Get(Func<Document, bool> func);

        List<Document> GetAll();
    }
}
