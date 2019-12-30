using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medicine.Entities;
using Medicine.Services;

namespace Medicine.Web.Models
{
    [Authorize]
    public static class AuthenticatedUserModel
    {
        public static User GetUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as Medicine.Authentication.CustomPrincipal).Identity as Medicine.Authentication.CustomIdentity;
            return authUser.User;
        }
    }
}