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
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(AmazonContext context) : base(context)
        {
        }

        public Task<List<Category>> FiltterByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
