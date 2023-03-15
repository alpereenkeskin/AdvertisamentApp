using Alperen.AdvertisamentApp.DataAccess.Contexts;
using Alperen.AdvertisamentApp.DataAccess.Interfaces;
using Alperen.AdvertisamentApp.DataAccess.Repositories;
using Alperen.AdvertisamentApp.Entities;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisamentContext _context;

        public Uow(AdvertisamentContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public Task SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
