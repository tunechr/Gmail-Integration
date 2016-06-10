using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using System;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;

namespace Google.Authentication.Controllers
{
    public class AppFlowMetaData : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
            {
                ClientId = "780824686231-q4osls39htmqbqtb9qjk4uuuqbep7imo.apps.googleusercontent.com",
                ClientSecret = "JKpjpi3fI9SvvJXIclkvOAYy"
            },
            Scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.SpreadsheetsReadonly },
            DataStore = new FileDataStore("Sheets.Api.Auth.Store")
        });

        public override string GetUserId(System.Web.Mvc.Controller controller)
        {
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();
        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}