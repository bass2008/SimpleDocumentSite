using AlphaLeasing.Common.Models;
using FluentNHibernate.Mapping;

namespace AlphaLeasing.DataAccess.Mappings
{
    public class DocumentsMap : ClassMap<Document>
    {
        public DocumentsMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Date);
            Map(x => x.Author);

            Table("Document");
        }
    }
}
