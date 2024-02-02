using Amazon.Application.Contracts;
using Amazon.Context;
using Amazon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(AmazonContext context):base(context) { }
        public Task<List<Product>> FillterByNme(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> FillterByPrice(decimal Price)
        {
            throw new NotImplementedException();
        }
    }
}
