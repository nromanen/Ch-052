using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
    [AllowAnonymous]
=======
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

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IService<FeedbackDTO> service;
<<<<<<< HEAD

        public FeedbackController(IService<FeedbackDTO> s)
        {
            service = s;
        }

=======
        IUserService<AspNetUsersDTO> userService;
        IFeedbackAwareService<FeedbackDTO> feedbackService;

        public FeedbackController(IService<FeedbackDTO> s, IUserService<AspNetUsersDTO> us, IFeedbackAwareService<FeedbackDTO> fs)
        {
            service = s;
            userService = us;
            feedbackService = fs;
        }

        [AllowAnonymous]
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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

<<<<<<< HEAD
        [HttpPost]
        [Route("add")]
        public FeedbackDTO Add(FeedbackDTO dto)
        {
            return service.Create(dto);
        }

=======
        [AllowAnonymous]
        [HttpGet]
        [Route("getByAdvertisement/{id}")]
        public IEnumerable<FeedbackDTO> GetByAdvertisement(int id)
        {
            return feedbackService.GetByAdvertisement(id);
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
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        [HttpPut]
        [Route("edit")]
        public void Update(FeedbackDTO dto)
        {
<<<<<<< HEAD
            service.Update(dto);
        }

=======
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
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
