using AlphaLeasing.Common.Models;
using FluentNHibernate.Mapping;

namespace AlphaLeasing.DataAccess.Mappings
{
    public class UsersMap : ClassMap<User>
    {
        public UsersMap()
        {
            Id(x => x.Id);
            Map(x => x.Login);
            Map(x => x.Password);

            HasMany(x => x.Documents)
                .KeyColumn("UserId");
        }
    }
}
