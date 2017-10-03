using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.Web.Http;
using Advertisements.BusinessLogic.Mapper;
namespace Advertisements.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/type")]
    public class TypeController : ApiController
    {
        IMyService<AdvertisementType,TypeDTO> service;

        public TypeController(IMyService<AdvertisementType, TypeDTO> s)
        {
            service = s;
            service._mapper = new MyTypeMapper();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<TypeDTO> Get()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public TypeDTO Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(TypeDTO dto)
        {
            service.Create(dto);
        }

        [HttpPut]
        [Route("edit")]
        public void Update(TypeDTO dto)
        {
            service.Update(dto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
