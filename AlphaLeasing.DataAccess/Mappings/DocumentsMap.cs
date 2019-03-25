using AlphaLeasing.Common.Models;
using AlphaLeasing.Common.Validation;
using FluentNHibernate.Mapping;

namespace AlphaLeasing.DataAccess.Mappings
{
    public class DocumentsMap : ClassMap<Document>
    {
        public DocumentsMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(DocumentValidation.NameLength);
            Map(x => x.Date);

            References(x => x.User)
                .Not.Nullable()
                .Column("UserId");
        }
    }
}
