using Medicine.Common;
using Medicine.Web.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class CompanyPharmacyController : Controller
    {
        private CompanyPharmacyModel _companyPharmacyModel;

        public CompanyPharmacyController()
        {
            _companyPharmacyModel = new CompanyPharmacyModel();
        }

        public ActionResult Company()
        {
            return View(_companyPharmacyModel.GetAllCompany());
        }

        public ActionResult Pharmacy()
        {
            return View(_companyPharmacyModel.GetAllPharmacy());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CompanyPharmacyModel model)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var newId = model.Add();
                if(model.UserRole == Role.Company)
                    return RedirectToAction("Company");
                else if (model.UserRole == Role.Pharmacy)
                    return RedirectToAction("Pharmacy");
            }

            return View(model);
        }
    }
}