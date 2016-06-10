using Google.Apis.Auth.OAuth2.Mvc;
using Google.Authentication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Google.Authentication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {           
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetaData()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential != null)
            {
                //var service = new DriveService(new BaseClientService.Initializer
                //{
                //    HttpClientInitializer = result.Credential,
                //    ApplicationName = "ASP.NET MVC Sample"
                //});

                //// YOUR CODE SHOULD BE HERE..
                //// SAMPLE CODE:
                //var list = await service.Files.List().ExecuteAsync();
                //ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
                return View();
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
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