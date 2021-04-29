using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using YogaStudio.App.Controllers;
using YogaStudio.App.Data;
using YogaStudio.App.Data.UnitOfWork;
using YogaStudio.App.Models.EntityModels;

namespace YogaStudio.App.Areas.Trainner.Controllers
{
    public class TrainnerAvailabilitiesController : BaseController
    {
        private YogaStudioContext db = new YogaStudioContext();

        public TrainnerAvailabilitiesController(IYogaStudioData data)
            : base(data)
        {
        }

        public TrainnerAvailabilitiesController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        // GET: Trainner/TrainnerAvailabilities
        public ActionResult Index()
        {
            return View(db.TrainnerAvailabilities.ToList());
        }

        // GET: Trainner/TrainnerAvailabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainnerAvailability trainnerAvailability = db.TrainnerAvailabilities.Find(id);
            if (trainnerAvailability == null)
            {
                return HttpNotFound();
            }
            return View(trainnerAvailability);
        }

        // GET: Trainner/TrainnerAvailabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainner/TrainnerAvailabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,From,To,TrainnerId")] TrainnerAvailability trainnerAvailability)
        {
            if (ModelState.IsValid)
            {
                trainnerAvailability.TrainnerId = this.UserProfile.Id;
                db.TrainnerAvailabilities.Add(trainnerAvailability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainnerAvailability);
        }

        // GET: Trainner/TrainnerAvailabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainnerAvailability trainnerAvailability = db.TrainnerAvailabilities.Find(id);
            if (trainnerAvailability == null)
            {
                return HttpNotFound();
            }
            return View(trainnerAvailability);
        }

        // POST: Trainner/TrainnerAvailabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,From,To,TrainnerId")] TrainnerAvailability trainnerAvailability)
        {
            if (ModelState.IsValid)
            {
                trainnerAvailability.TrainnerId = this.UserProfile.Id;
                db.Entry(trainnerAvailability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainnerAvailability);
        }

        // GET: Trainner/TrainnerAvailabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainnerAvailability trainnerAvailability = db.TrainnerAvailabilities.Find(id);
            if (trainnerAvailability == null)
            {
                return HttpNotFound();
            }
            return View(trainnerAvailability);
        }

        // POST: Trainner/TrainnerAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainnerAvailability trainnerAvailability = db.TrainnerAvailabilities.Find(id);
            db.TrainnerAvailabilities.Remove(trainnerAvailability);
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
