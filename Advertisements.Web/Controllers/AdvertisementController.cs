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
using System.Threading.Tasks;
using System.Text;
using Advertisements.Web.Models;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Advertisement")]
    public class AdvertisementController : ApiController
    {
        IUserAwareService<AdvertisementDTO> userService;
        IAdvertisementAwareService<AdvertisementDTO> advertService;
        IMyService<Advertisement, AdvertisementDTO> service;
        public AdvertisementController(IUserAwareService<AdvertisementDTO> us, 
            IAdvertisementAwareService<AdvertisementDTO> advs, IMyService<Advertisement, AdvertisementDTO> myServ)
        {
            userService = us;
            advertService = advs;
            service = myServ;
            service._mapper = new MyAdvertisementMapper();
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">PageSize and Page</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("takepage")]
        public IEnumerable<AdvertisementDTO> TakePage(PaginationModel model)
        {
            return advertService.Get(model.Page, model.PageSize);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getmyadv/{id}")]
        public AdvertisementDTO GetMyAdvertisement(int id)
        {
            return this.service.Get(id) as AdvertisementDTO;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getmyadvs")]
        public IEnumerable<IDTO> GetMyAdvertisements()
        {
            return this.service.GetAll(adv => adv.Resources);          
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getadvcount")]
        public int GetAdvertisementsCount()
        {
            return advertService.GetCount();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementDTO Get(int id)
        {
            return service.Get(id,adv=>adv.Resources);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("find/{keyword}")]
        public  IEnumerable<AdvertisementDTO> Find(string keyword)
        {   
            return advertService.Find(keyword);
        }



        [AllowAnonymous]
        [HttpGet]
        [Route("findbyuser/{id}")]
        public IEnumerable<AdvertisementDTO> FindByUser(string id)
        {
            return userService.GetByUser(id);
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
            string root = HttpContext.Current.Server.MapPath("~/assets/uploads");
            string guid, fileName, dest, newName;
            HttpResponseMessage response = new HttpResponseMessage();
            StringBuilder content = new StringBuilder();

            if (Request.Content.IsMimeMultipartContent())
            {
                var provider = new MultipartFormDataStreamProvider(root);
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData fileData in provider.FileData)
                {
                    if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                    {
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
                    }

                    fileName = fileData.Headers.ContentDisposition.FileName;

                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }

                    guid = Guid.NewGuid().ToString();
                    newName = guid + "-" + fileName;
                    dest = Path.Combine(root, newName);

                    File.Move(fileData.LocalFileName, dest);
                    content.Append("../../../assets/uploads/" + newName + " ");
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(content.ToString().Remove(content.ToString().Length - 1))
                };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent("This request is not properly formatted")
                };
            }
        }
    }
}
