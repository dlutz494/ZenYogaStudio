namespace YogaStudio.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Implementations;

    public class CreditCardController : BaseController
    {
        private CreditCardService service;

        public CreditCardController(IYogaStudioData data, CreditCardService service)
            : base(data)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<CreditCardViewModel> creditCards = service.GetAllCreditCards(UserProfile.Id);

            return View(creditCards);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreditCardBindingModel model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (model != null && ModelState.IsValid)
            {
                this.service.CreateNewCreditCard(model, UserProfile.Id);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CreditCardViewModel viewModel = service.GetEditCreditCard(id);

            if (viewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreditCardBindingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                service.EditCreditCard(model);

                return RedirectToAction("Index");
            }

            return this.View();

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CreditCardViewModel viewModel = service.GetDeleteCreditCard(id);

            if (viewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteCreditCard(id);

            return RedirectToAction("Index");
        }
    }
}