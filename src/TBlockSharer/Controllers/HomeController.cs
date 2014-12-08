using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LinqToTwitter;

namespace TBlockSharer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public async Task<ActionResult> Login()
        {
            var auth = new MvcSignInAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"]
                }
            };

            string callbackUrl = Request.Url.ToString().Replace("Login", "LoginComplete");
            return await auth.BeginAuthorizationAsync(new Uri(callbackUrl));
        }

        public async Task<ActionResult> LoginComplete()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            await auth.CompleteAuthorizeAsync(Request.Url);
            //return View("Index", new Models.Index() { BlockedUsers = new string[] { "hello" } });
            return RedirectToAction("Index");
        }
    }
}