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
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IMyService<Feedback,FeedbackDTO> service;
        IUserService<AspNetUsersDTO> userService;
        IFeedbackAwareService<FeedbackDTO> feedbackService;

        public FeedbackController(IMyService<Feedback, FeedbackDTO> s, IUserService<AspNetUsersDTO> us, IFeedbackAwareService<FeedbackDTO> fs)
        {
            service = s;
            service._mapper = new MyFeedBackMapper();
            userService = us;
            feedbackService = fs;
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
        [Route("alreadyCommented/{id}")]
        public bool AlreadyCommented(int id)
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            return feedbackService.AlreadyCommented(UserId, id);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public FeedbackDTO Get(int id)
        {
            return service.Get(id);
        }

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
                dto.CreationTime = DateTime.Now;
                dto.Username = System.Web.HttpContext.Current.User.Identity.GetUserName();
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
