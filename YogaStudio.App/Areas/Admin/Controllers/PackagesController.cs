using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YogaStudio.App.Data;
using YogaStudio.App.Models.EntityModels;

namespace YogaStudio.App.Areas.Admin.Controllers
{
    public class PackagesController : Controller
    {
        private YogaStudioContext db = new YogaStudioContext();

        // GET: Admin/Packages
        public ActionResult Index()
        {
            var packages = db.Packages.Include(c => c.Courses);
            return View(packages.ToList());
        }

        // GET: Admin/Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Admin/Packages/Create
        public ActionResult Create()
        {
            ViewBag.Courses = new MultiSelectList(db.Courses, "Id", "Name");

            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);
            var rolesUsers = manager.Roles.Single(x => x.Name == "Trainner").Users.ToList();
            var userIds = new List<string>();
            foreach (var roleUser in rolesUsers)
            {
                userIds.Add(roleUser.UserId);
            }
            var trainners = db.Users.Where(u => userIds.Contains(u.Id));
            ViewBag.TrainnerId = new SelectList(trainners, "Id", "UserName");
            
            return View();
        }

        // POST: Admin/Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Image,CourseId,TrainnerId")] Package package, int[] courseId, string trainnerId)
        {
            if (ModelState.IsValid)
            {
                package.TrainnerId = trainnerId;
                db.Packages.Add(package);
                db.SaveChanges();

                var packId = db.Packages.Count();

                if (courseId.Length > 0)
                {
                    foreach (var course in courseId)
                    {
                        var courseResult = db.Courses.FirstOrDefault(c => c.Id == course);
                        var pack = db.Packages.FirstOrDefault(p=>p.Id == packId);
                        pack.Courses.Add(courseResult);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.Courses = new MultiSelectList(db.Courses, "Id", "Name", package.Courses);
            return View(package);
        }

        // GET: Admin/Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Admin/Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Image")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Admin/Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Admin/Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
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
