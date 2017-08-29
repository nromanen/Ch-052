using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        IService<CategoryDTO> service;

        public CategoryController(IService<CategoryDTO>  s)
        {
            service = s;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<CategoryDTO> Get()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public CategoryDTO Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(CategoryDTO dto)
        {
           service.Create(dto);
        }

        [HttpPut]
        [Route("edit")]
        public void Update(CategoryDTO dto)
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
