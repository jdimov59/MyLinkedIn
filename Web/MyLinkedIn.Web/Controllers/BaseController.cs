using MyLinkedIn.Data;
using MyLinkedIn.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyLinkedIn.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private IMyLinkedInDataUoW data;
        private User userProfile;

        protected BaseController(IMyLinkedInDataUoW data)
        {
            Data = data;
        }

        protected BaseController(IMyLinkedInDataUoW data, User userProfile)
            : this(data)
        {
            UserProfile = userProfile;
        }

        protected IMyLinkedInDataUoW Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = Data.Users.All().FirstOrDefault(x => x.UserName == username);
                UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}