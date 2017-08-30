using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class ResourceService : IService<ResourceDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public ResourceService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(ResourceDTO item)
        {
            Resource Resource = ResourceMapper.CreateResource().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Resource>();
                repo.Create(Resource);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Resource>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public ResourceDTO Get(int id)
        {
            Resource Resource;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Resource>();
                Resource = repo.Get(id);
            }
            ResourceDTO dto = ResourceMapper.CreateResourceDTO().Map(Resource);
            return dto;
        }

        public IEnumerable<ResourceDTO> GetAll()
        {
            IEnumerable<Resource> categories;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Resource>();

                categories = repo.GetAll();
            }

            IEnumerable<ResourceDTO> dtos = ResourceMapper.CreateListResourceDTO().Map(categories).ToList();

            return dtos;
        }

        public void Update(ResourceDTO item)
        {
            Resource Resource = ResourceMapper.CreateResource().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Resource>();
                repo.Update(Resource);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
    }
}

