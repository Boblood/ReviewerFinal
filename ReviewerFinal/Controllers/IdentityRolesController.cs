using Microsoft.AspNet.Identity.EntityFramework;
using ReviewerFinal.CustomAttribute;
using ReviewerFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ReviewerFinal.Controllers
{
    public class IdentityRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityRoles
        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        public ActionResult Create()
        {
            return View();
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (db.Roles.Any(x => x.Name == role.Name))
                {
                    ViewBag.ErrorMessage = "This user already has the role specified";
                    return View();
                }
                else
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index"); 

                }
            }

            return View(role);
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [AuthorizeOrRedirect(Roles = "SiteAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole temp = db.Roles.Find(id);
            db.Roles.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}