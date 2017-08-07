using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
using System.Collections.Generic;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IService<FeedbackDTO> service = new FeedbackService(new UOWFactory());  

        [HttpGet]
        [Route("get")]
        public IEnumerable<FeedbackDTO> Get()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public FeedbackDTO Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public FeedbackDTO Add(FeedbackDTO dto)
        {
            return service.Create(dto);
        }

        [HttpPut]
        [Route("edit")]
        public void Update(FeedbackDTO dto)
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
