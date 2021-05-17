using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortenService.Models;
using UrlShortenService.UserFunctions;

namespace UrlShortenService.Controllers
{
    public class HomeController : Controller
    {
        URL_DatabaseEntities db = new URL_DatabaseEntities();

        public ActionResult Index(URL uRL = null)
        {
            if (uRL != null)
                return View(uRL);
            return View();
        }

        [HttpPost]
        public ActionResult Create(URL uRL)
        {
            uRL.SHORT_URL = generateShortUrl();
            if (!uRL.LONG_URL.StartsWith("https://"))
                uRL.LONG_URL = $"https://{uRL.LONG_URL}";

            if (ModelState.IsValid)
            {
                db.URLS.Add(uRL);
                db.SaveChanges();
                return RedirectToAction("Index", uRL);
            }
            
            return View();
        }

        public ActionResult ReDirect()
        {
           
            string FullUrl = Request.Url.ToString();

            string shortUrl = FullUrl.Substring(FullUrl.Length - 29);

            URL uRL = db.URLS.Where(i => i.SHORT_URL == shortUrl).FirstOrDefault();

            if (uRL == null)
                return RedirectToAction("index");
            return View(uRL);
        }

        public String generateShortUrl()
        {
            String ShortUrl = UserFunctions.UserFunctions.RandomString(5);
            while (db.URLS.Any(i => i.SHORT_URL == ShortUrl))
            {
                ShortUrl = UserFunctions.UserFunctions.RandomString(5);
            }
            string Domain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/";
            return Domain + ShortUrl;
        }

    }
}