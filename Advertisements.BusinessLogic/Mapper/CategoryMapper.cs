using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class CategoryMapper
    {

        public static ObjectsMapper<CategoryDTO, Category> CreateCategory()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<CategoryDTO, Category>(new DefaultMapConfig().
                ConvertUsing((CategoryDTO source) => new Category { Id = source.Id, Name = source.Name }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<CategoryDTO>, IEnumerable<Category>> CreateListCategory()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<CategoryDTO>, IEnumerable<Category>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<CategoryDTO>, IEnumerable<Category>>(a=>a.Select(CreateCategory().Map)));

            return mapper;
        }

        public static ObjectsMapper<Category, CategoryDTO> CreateCategoryDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Category, CategoryDTO>(new DefaultMapConfig().
                ConvertUsing((Category source) => new CategoryDTO { Id = source.Id, Name = source.Name }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<Category>, IEnumerable<CategoryDTO>> CreateListAdvertisementDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<Category>, IEnumerable<CategoryDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<Category>, IEnumerable<CategoryDTO>>(a=>a.Select(CreateCategoryDTO().Map)));

            return mapper;
        }
    }
}
