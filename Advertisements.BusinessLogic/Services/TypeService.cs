using Advertisements.BusinessLogic.Mapper;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Repositories;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Services
{
    public class TypeService : IItemService<TypeDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public TypeService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(TypeDTO item)
        {
            AdvertisementType type = TypeMapper.CreateType().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();
                repo.Create(type);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public TypeDTO Get(int id)
        {
            AdvertisementType type;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();
                type = repo.Get(id);
            }
            TypeDTO dto = TypeMapper.CreateTypeDTO().Map(type);
            return dto;
        }

        public IEnumerable<TypeDTO> GetAll()
        {
            IEnumerable<AdvertisementType> types;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                types = repo.GetAll(o => o.Advertisements);
            }

            IEnumerable<TypeDTO> dtos = TypeMapper.CreateListTypeDTO().Map(types).ToList();

            return dtos;
        }

        public void Update(TypeDTO item)
        {
            AdvertisementType types = TypeMapper.CreateType().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();
                repo.Update(types);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
        public bool IsValid(TypeDTO item)
        {
            if(item.Name == null || item.Id != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
