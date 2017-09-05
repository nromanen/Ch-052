using System;
using System.Collections.Generic;
using System.IO;           
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Advertisement")]
    public class AdvertisementController : ApiController
    {


        IService<AdvertisementDTO> service;
        IUserAwareService<AdvertisementDTO> userService;

        public AdvertisementController(IService<AdvertisementDTO> s, IUserAwareService<AdvertisementDTO> us)
        {
            service = s;
            userService = us;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<AdvertisementDTO> Get()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementDTO Get(int id)
        {
            return service.Get(id);
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public void Add(AdvertisementDTO dto)
        {
            service.Create(dto);
        }

        
        [Authorize]
        [HttpPut]
        [Route("edit")]
        public void Update(AdvertisementDTO dto)
        {
            service.Update(dto);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }

        [Authorize]
        [HttpGet]
        [Route("get/current")]
        public IEnumerable<AdvertisementDTO> GetCurrentUsersAdv()
        {
            string userId = Thread.CurrentPrincipal.Identity.GetUserId();
            return userService.GetByUser(userId);
        }

        [Authorize]
        [HttpPost]
        [Route("upload")]
        public async Task<HttpResponseMessage> Upload()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/assets/uploads");
            var provider = new CustomMultipartFormDataStreamProvider(root);

            var task = await request.Content.ReadAsMultipartAsync(provider);

            return new HttpResponseMessage()
            {
                Content = new StringContent("../../../assets/uploads/" + task.GetLocalFileName())
            };
        }

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase file)
        //{

        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //        file.SaveAs(path);
        //    }

        //    return RedirectToAction("Index");
        //}

        public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
        {
            string imageName;      
            public CustomMultipartFormDataStreamProvider(string path) : base(path) { }
            

            public override string GetLocalFileName(HttpContentHeaders headers)
            {
                var guid = Guid.NewGuid().ToString();
                imageName = guid +
                            headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                return imageName;
            }

            public string GetLocalFileName()
            {
                return imageName;
            }

        }
    }
}
