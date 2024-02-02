using Amazon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Contracts
{
    public interface ICategoryRepository:IRepository<Category,int>
    {
        public Task<List<Category>> FiltterByName(string name);
    }
}
