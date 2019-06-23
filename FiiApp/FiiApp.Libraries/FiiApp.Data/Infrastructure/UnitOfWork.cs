using FiiApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FiiApp.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(FiiAppContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
