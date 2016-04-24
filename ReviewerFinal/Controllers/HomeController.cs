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
using MoreLinq;

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
            var topFiveReviewedGames = FindFiveMostReviewed();
            for (int i = 0; i < 5; i++)
            {
                listOfPics.Add(topFiveReviewedGames[i].GameImage);
            }

            ViewBag.FirstFiveGames = listOfPics;

            return View();
        }

        private List<Game> FindFiveMostReviewed()
        {
            var games = db.Games.ToList();
            var reviews = db.GameReviews.ToList();
            var mostReviewed = db.GameReviews.GroupBy(r => r.RefID).OrderByDescending(r => r.Count()).Select(r => r).ToList();
            List<Game> temp = new List<Game>();
            for (int i = 0; i < 5; i++)
            {
                temp.Add(db.Games.Find(mostReviewed[i].Key));
            }

          
            return temp;
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