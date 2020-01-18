using Medicine.Common;
using Medicine.Web.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private MedicineModel _medicineModel;

        public MedicineController()
        {
            _medicineModel = new MedicineModel();
        }
        
        public ActionResult Index()
        {
            if(User.IsInRole(Role.Admin))
                return View(_medicineModel.GetAll());
            else
                return View(_medicineModel.GetAll().Where(x => x.CompanyId == Medicine.Web.Models.AuthenticatedUserModel.GetUserFromIdentity().Id));
        }

        public ActionResult Pending()
        {
            return View(_medicineModel.GetAllPending());
        }

        [HttpGet]
        public ActionResult Add()
        {
            _medicineModel.LoadAllListData();
            return View(_medicineModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = model.Add();
                return RedirectToAction("Details", new { id = newId });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            _medicineModel = new MedicineModel(id);
            _medicineModel.LoadAllListData();
            return View(_medicineModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = model.Update();
                return RedirectToAction("Details", new { id = newId });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            _medicineModel = new MedicineModel(id);
            _medicineModel.LoadAllListData();
            return View(_medicineModel);
        }

        public ActionResult ChangeStatus(string id, EnumMedicineStatus status)
        {
            _medicineModel.ChangeStatus(id, status);
            return RedirectToAction("Index");
        }
    }
}