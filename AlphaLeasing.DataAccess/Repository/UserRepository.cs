using AlphaLeasing.Common.Models;
using NHibernate;
using System;
using System.Linq;

namespace AlphaLeasing.DataAccess.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        protected ISession _session;
        
        public UserRepository(ISession session)
        {
            _session = session; 
        }
                
        public User GetByLogin(string login)
        {
            return _session.Query<User>().FirstOrDefault(x => x.Login == login);
        }
                
        public void Dispose()
        {
            _session.Dispose();
        }
    }
}