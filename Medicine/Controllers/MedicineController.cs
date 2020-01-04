using Medicine.Common;
using Medicine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine.Web.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Search(MedicineSearchModel model)
        {
            model = (model ?? new MedicineSearchModel());
            var result = new MedicineSearchModel(model.SMedicineName, model.SMedicineSize, model.SMedicineType);
            return View(result);
        }

        [Authorize(Roles = Role.NormalUser)]

        [HttpGet]
        public ActionResult Add()
        {
            var model = new MedicineModel();
            model.LoadAllListData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = model.Add();
                return RedirectToAction("AddSuccess");
            }

            model.LoadAllListData();
            return View(model);
        }
        public ActionResult AddSuccess()
        {
            return View();
        }

        [Authorize(Roles = Role.NormalUser)]
        public ActionResult Report(string id)
        {
            var model = new MedicineReportModel();
            model.Complainant = AuthenticatedUserModel.GetUserFromIdentity();
            model.ComplainantId = model.Complainant.Id;
            model.MedicineInfo = model.GetMedicineInfo(id);
            model.MedicineInfoId = model.MedicineInfo.Id;
            model.Pharmacies = model.GetAllPharmacies();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(MedicineReportModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = model.Add();
                return RedirectToAction("ReportSuccess");
            }

            model.Complainant = AuthenticatedUserModel.GetUserFromIdentity();
            model.MedicineInfo = model.GetMedicineInfo(model.MedicineInfoId);
            model.Pharmacies = model.GetAllPharmacies();
            return View(model);
        }
        public ActionResult ReportSuccess()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            var model = new MedicineModel(id);
            return View(model);
        }
    }
}