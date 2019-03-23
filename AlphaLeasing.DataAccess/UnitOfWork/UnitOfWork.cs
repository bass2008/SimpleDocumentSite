using NHibernate;
using System;
using System.Threading.Tasks;

namespace AlphaLeasing.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected ITransaction _transaction;

        public UnitOfWork(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                //var logger = Logger.GetLogger();
                //logger.Error(ex.Message);
                throw; 
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                //var logger = Logger.GetLogger();
                //logger.Error(ex.Message);
                throw; 
            }
        }
    }
}