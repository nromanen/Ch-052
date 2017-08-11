using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advertisements.Web.Models
{
    public class CreateRoleBindingModel
    {
        [Required]
        [Display(Name="Role Name")]
        public string Name { get; set; }
    }
    public class UsersInRoleModel
    {
        public string Id { get; set; }
        public List<string> EnrolledUsers { get; set; }
        public List<string> RemovedUsers { get; set; }
    }

}