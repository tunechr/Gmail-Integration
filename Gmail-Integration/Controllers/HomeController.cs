using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2.Flows;

using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using Google.Apis.Auth.OAuth2.Responses;

using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using System.Text;

namespace Gmail_Integration.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var identity = AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie);

            var claims = HttpContext.GetOwinContext().Authentication.User.Claims;

            var cred = await GetCredentialForApiAsync();

                return View(); ;

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cred,
                ApplicationName = "",
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // List labels.
            StringBuilder sb = new StringBuilder();

            IList<Label> labels = request.Execute().Labels;
            sb.AppendLine("Labels:");
            if (labels != null && labels.Count > 0)
            {
                foreach (var labelItem in labels)
                {
                    sb.AppendLine(  labelItem.Name);
                }
            }
            else
            {
                sb.AppendLine("No labels found.");
            }

            ViewBag.Labels = sb.ToString();
            return View();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task<UserCredential> GetCredentialForApiAsync()
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "780824686231-q4osls39htmqbqtb9qjk4uuuqbep7imo.apps.googleusercontent.com",
                    ClientSecret = "JKpjpi3fI9SvvJXIclkvOAYy",
                },
                Scopes = new[] {
        "https://www.googleapis.com/auth/plus.login",
        "https://www.googleapis.com/auth/plus.me",
        "https://www.googleapis.com/auth/userinfo.email" }
            };
            var flow = new GoogleAuthorizationCodeFlow(initializer);

            var identity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie);

            var userId = identity.FindFirstValue("GoogleUserId");

            var token = new TokenResponse()
            {
                AccessToken = identity.FindFirstValue("Google_AccessToken"),
                RefreshToken = identity.FindFirstValue("GoogleRefreshToken"),
                Issued = DateTime.FromBinary(long.Parse(identity.FindFirstValue("GoogleTokenIssuedAt"))),
                ExpiresInSeconds = long.Parse(identity.FindFirstValue("GoogleTokenExpiresIn")),
            };

            return new UserCredential(flow, userId, token);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}