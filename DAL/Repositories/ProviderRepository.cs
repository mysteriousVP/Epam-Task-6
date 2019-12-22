using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        private readonly DataContext _dataContext;
        public ProviderRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Provider>> GetProviders()
        {
            return _dataContext.Providers;
        }
    }
}
