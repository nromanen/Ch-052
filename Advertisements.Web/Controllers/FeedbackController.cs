using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IService<FeedbackDTO> service;

        public FeedbackController(IService<FeedbackDTO> s)
        {
            service = s;
        }

        [AllowAnonymous]
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

        [Authorize]
        [HttpPost]
        [Route("add")]
        public void Add(FeedbackDTO dto)
        {
            service.Create(dto);
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
