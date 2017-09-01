using Advertisements.BusinessLogic.Services;
<<<<<<< HEAD
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
=======
using Advertisements.DTO.Models;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
using System.Collections.Generic;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
<<<<<<< HEAD
    [AllowAnonymous]
    [RoutePrefix("api/Category")]
=======
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/category")]
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    public class CategoryController : ApiController
    {
        IService<CategoryDTO> service;

        public CategoryController(IService<CategoryDTO>  s)
        {
            service = s;
        }

<<<<<<< HEAD
        
=======
        [AllowAnonymous]
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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
<<<<<<< HEAD
        public CategoryDTO Add(CategoryDTO dto)
        {
            return service.Create(dto);
=======
        public void Add(CategoryDTO dto)
        {
           service.Create(dto);
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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
