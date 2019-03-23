using AlphaLeasing.Common.Models;
using System.Collections.Generic;

namespace AlphaLeasing.Mapping
{
    public interface IDocumentMapper
    {
        List<List<string>> MapDocuments(List<Document> documents);

        List<string> MapDocument(Document doc);
    }
}