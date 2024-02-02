using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Contracts
{
    public interface IRepository<Tentity,Tid>
    {
        public Task<Tentity> CreateAsync(Tentity entity);
        public Task<IQueryable<Tentity>> GetAllAsync();
        public Task<Tentity> GetById(Tid id);
        public Task<bool> UpdateAsync(Tentity entity);
        public Task<bool> DeleteAsync(Tentity tentity);
        public Task<int> SaveChangesAsync();
    }
}
