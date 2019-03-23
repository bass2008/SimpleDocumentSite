using System.Threading.Tasks;

namespace AlphaLeasing.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        Task SaveChangesAsync();
    }
}