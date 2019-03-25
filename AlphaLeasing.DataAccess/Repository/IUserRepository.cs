using AlphaLeasing.Common.Models;

namespace AlphaLeasing.DataAccess.Repository
{
    public interface IUserRepository
    {
        User GetByLogin(string login);
    }
}
