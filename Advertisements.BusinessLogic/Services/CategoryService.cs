using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public CategoryService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(CategoryDTO item)
        {
            Category category = CategoryMapper.CreateCategory().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Category>();
                repo.Create(category);
                uow.BeginTransaction();
                uow.Commit();                                 
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Category>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public CategoryDTO Get(int id)
        {
            Category category;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Category>();
                category = repo.Get(id);
            }
            CategoryDTO dto = CategoryMapper.CreateCategoryDTO().Map(category);
            return dto;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<Category> categories;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Category>();

                categories = repo.GetAll();
            }
            //http://localhost:53929/api/Category/getcategories
            IEnumerable<CategoryDTO> dtos = CategoryMapper.CreateListAdvertisementDTO().Map(categories).ToList();

            return dtos;
        }

        public void Update(CategoryDTO item)
        {
            Category category = CategoryMapper.CreateCategory().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Category>();
                repo.Update(category);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
    }
}

