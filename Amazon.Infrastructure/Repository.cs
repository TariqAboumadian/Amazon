using Amazon.Application.Contracts;
using Amazon.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure
{
    public class Repository<Tentity, Tid> : IRepository<Tentity, Tid> where Tentity : class
    {
        private readonly AmazonContext _Context;
        private readonly DbSet<Tentity> _dbset;
        public Repository(AmazonContext context)
        {
            _Context = context;
            _dbset = context.Set<Tentity>();
        }
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            var res = await _dbset.AddAsync(entity);
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(Tentity entity)
        {
            var res =await Task.FromResult( _dbset.Remove(entity));
            return res != null ? true : false;
        }

        public Task<IQueryable<Tentity>> GetAllAsync()
        {
            return Task.FromResult(_dbset.Select(p=>p));
        }

        public async Task<Tentity> GetById(Tid id)
        {
            return await _dbset.FindAsync(id)??default!;
        }

        public async Task<int> SaveChangesAsync()
        {
            //return Task.FromResult(_Context.SaveChanges());
            return await _Context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Tentity entity)
        {
            var res =await Task.FromResult(_dbset.Update(entity));
            return res != null ? true : false;
        }
    }
}
