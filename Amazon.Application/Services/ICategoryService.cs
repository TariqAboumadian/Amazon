using Amazon.Domain;
using Amazon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Services
{
    public interface ICategoryService
    {
        public Task<CreateOrUpdateCategoryDTO> Create(CreateOrUpdateCategoryDTO category);
        public Task<List<GetAllCAtegoriesDTO>> GetAllCategoryPagination(int item,int pagenumber);
    }
}
