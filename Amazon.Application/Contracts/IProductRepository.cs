using Amazon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Contracts
{
    public interface IProductRepository:IRepository<Product,int>
    {
        public Task<List<Product>> FillterByNme(string Name);
        public Task<List<Product>> FillterByPrice(decimal Price);
    }
}
