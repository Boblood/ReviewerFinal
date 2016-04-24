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
    public class GameReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameReviews
        [AllowAnonymous]
        public ActionResult Index()
        {
            var gameReviews = db.GameReviews.Include(g => g.GameID);
            return View(gameReviews.ToList());
        }

        [AllowAnonymous]
        public ActionResult ListReviewByGame(int gameID)
        {
            var gameReviews = db.GameReviews.Where(x => x.RefID == gameID).ToList();

            var game = db.Games.Find(gameID);
            ViewBag.GameName = game.Name;
            ViewBag.GameID = game.GameID;

            return View(gameReviews);
        }

        // GET: GameReviews/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            return View(gameReview);
        }

        // GET: GameReviews/Create
        [AuthorizeOrRedirect(Roles = "User")]
        public ActionResult Create(int id)
        {
            ViewBag.RefID = new SelectList(db.Games, "GameID", "Name", id);
            return View();
        }

        // POST: GameReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeOrRedirect(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,DateCreated,Content,RefID")] GameReview gameReview)
        {
            if (ModelState.IsValid)
            {
                gameReview.DateCreated = DateTime.Now;
                db.GameReviews.Add(gameReview);
                db.SaveChanges();
                return RedirectToAction("ListReviewByGame", new { gameID = gameReview.RefID });
            }

            ViewBag.RefID = new SelectList(db.Games, "GameID", "Name", gameReview.RefID);
            return View(gameReview);
        }

        // GET: GameReviews/Edit/5
        [AuthorizeOrRedirect(Roles = "GameAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefID = new SelectList(db.Games, "GameID", "Name", gameReview.RefID);
            return View(gameReview);
        }

        // POST: GameReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeOrRedirect(Roles = "GameAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,DateCreated,Content,RefID")] GameReview gameReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefID = new SelectList(db.Games, "GameID", "Name", gameReview.RefID);
            return View(gameReview);
        }

        // GET: GameReviews/Delete/5
        [AuthorizeOrRedirect(Roles = "GameAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            return View(gameReview);
        }

        // POST: GameReviews/Delete/5
        [AuthorizeOrRedirect(Roles = "GameAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameReview gameReview = db.GameReviews.Find(id);
            db.GameReviews.Remove(gameReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
