using AlphaLeasing.Common.Models;
using System.Collections.Generic;

namespace AlphaLeasing.Mapping
{
    public class DocumentMapper : IDocumentMapper
    {
        private const int MaxNameLength = 30;
        
        public List<List<string>> MapDocuments(List<Document> documents)
        {
            var mapped = new List<List<string>>();
            foreach (var item in documents)
            {
                var list = MapDocument(item);
                mapped.Add(list);
            }

            return mapped;
        }

        public List<string> MapDocument(Document doc)
        {
            var listItem = new List<string>();
            var mappedName = doc.Name.Length > 30 ?
                $"{doc.Name.Substring(0, 30)}...":
                doc.Name;

            listItem.Add(mappedName);
            listItem.Add(doc.Date);
            listItem.Add(doc.Author);
            listItem.Add(doc.Link);
            return listItem;
        }
    }
}