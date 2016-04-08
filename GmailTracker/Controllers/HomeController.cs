using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GmailTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var claims = HttpContext.GetOwinContext().Authentication.User.Claims;

            return View();
        }

 //       private async Task<UserCredential> GetCredentialForApiAsync()
 //       {
            

 //         //  ClaimsIdentity identity = await HttpContext.GetOwinContext().Authentication
 //// .GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);

 //           var initializer = new GoogleAuthorizationCodeFlow.Initializer
 //           {
 //               ClientSecrets = new ClientSecrets
 //               {
 //                   ClientId = "Xxxxxxxxx.apps.googleusercontent.com",
 //                   ClientSecret = "YYyyyyyyyyy",
 //               },
 //               Scopes = new[] {
 //       "https://www.googleapis.com/auth/plus.login",
 //       "https://www.googleapis.com/auth/plus.me",
 //       "https://www.googleapis.com/auth/userinfo.email" }
 //           };
 //           var flow = new GoogleAuthorizationCodeFlow(initializer);

 //           var identity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie);

 //           var userId = identity.FindFirstValue("GoogleUserId");

 //           var token = new TokenResponse()
 //           {
 //               AccessToken = identity.FindFirstValue("Google_AccessToken"),
 //               RefreshToken = identity.FindFirstValue("GoogleRefreshToken"),
 //               Issued = DateTime.FromBinary(long.Parse(identity.FindFirstValue("GoogleTokenIssuedAt"))),
 //               ExpiresInSeconds = long.Parse(identity.FindFirstValue("GoogleTokenExpiresIn")),
 //           };

 //           return new UserCredential(flow, userId, token);
 //       }
    }
}
