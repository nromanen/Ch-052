using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Http;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        IUserService<AspNetUsersDTO> userService;
        IFeedbackService<FeedbackDTO> feedbackService;

        public FeedbackController(IUserService<AspNetUsersDTO> us, IFeedbackService<FeedbackDTO> fs)
        {
            userService = us;
            feedbackService = fs;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<FeedbackDTO> Get()
        {
            return feedbackService.GetAll();
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
            return feedbackService.Get(id);
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
            if (feedbackService.IsValid(dto))
            {
                try
                {
                    dto.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    feedbackService.Create(dto);
                }
                catch (FeedbackService.PermissionDeniedException ex)
                {
                    HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)400, ex.StatusCode);
                    throw new HttpResponseException(response);
                }
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
                feedbackService.Update(dto);
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
            feedbackService.Delete(id);
        }
    }
}
