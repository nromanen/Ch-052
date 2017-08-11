using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http.Routing;

namespace Advertisements.Web.Models
{
    public class ModelFactory
    {
        public static RoleReturnModel Create(IdentityRole appRole)
        {
            return new RoleReturnModel
            {
                Url = new UrlHelper().Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }

    public class RoleReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}