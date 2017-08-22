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
using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Http;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IService<FeedbackDTO> service;
        IUserService<AspNetUsersDTO> userService;

        public FeedbackController(IService<FeedbackDTO> s, IUserService<AspNetUsersDTO> us)
        {
            service = s;
            userService = us;
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
            try
            {
                dto.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                service.Create(dto);
            }
            catch (FeedbackService.PermissionDeniedException ex)
            {
                HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)400, ex.StatusCode);
                throw new HttpResponseException(response);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("edit")]
        public void Update(FeedbackDTO dto)
        {
            try
            {
                dto.VotedUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    service.Update(dto);
            }
            catch (FeedbackService.PermissionDeniedException ex)
            {
                HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)400, ex.StatusCode);
                throw new HttpResponseException(response);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
