using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewerFinal.Models;
using ReviewerFinal.CustomAttribute;

namespace ReviewerFinal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var games = db.Games.ToList();
            var listOfPics = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                listOfPics.Add( games[i].GameImage);
            }

            ViewBag.FirstFiveGames = listOfPics;

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AuthorizeOrRedirect(Roles = "GameAdmin, SiteAdmin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}