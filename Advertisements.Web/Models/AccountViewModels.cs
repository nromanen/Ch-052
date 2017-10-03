﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertisements.Web.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }
    }

    public class RestorePasswordReqViewModel
    {
        public string Email;
    }

    public class CheckPassRestoreDataViewModel
    {
        public string Email;
        public string Token;
    }


    public class RestorePasswordViewModel
    {
        public string Email;
        public string EmailToken;
        public string NewPassword;
    }

    public class PaginationModel
    {
        public int PageSize;
        public int Page;
    }
    
}
