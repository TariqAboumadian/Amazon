using Amazon.Domain;
using Amazon.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Mapper
{
    internal class MyMappingTool:Profile
    {
        public MyMappingTool()
        {
            CreateMap<Category, GetAllCAtegoriesDTO>().ReverseMap();
            CreateMap<Category,CreateOrUpdateCategoryDTO>().ReverseMap();
        }
    }
}
