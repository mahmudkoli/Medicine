using Medicine.Common;
using Medicine.Entities;
using Medicine.Web.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class MedicineReportController : Controller
    {
        private MedicineReportModel _medicineReportModel;

        public MedicineReportController()
        {
            _medicineReportModel = new MedicineReportModel();
        }

        // GET: Admin/MedicineReport
        public ActionResult Index()
        {
            var result = new List<MedicineReport>();

            if(User.IsInRole(Role.Admin))
             result = _medicineReportModel.GetAll().ToList();
            else if(User.IsInRole(Role.Company))
                result = _medicineReportModel.GetAllForCompany().ToList();
            else if(User.IsInRole(Role.Pharmacy))
                result = _medicineReportModel.GetAllForPharmacy().ToList();

            return View(result);
        }

        public ActionResult Pending()
        {
            var result = new List<MedicineReport>();

            if (User.IsInRole(Role.Admin))
                result = _medicineReportModel.GetAllPending().ToList();
            else if (User.IsInRole(Role.Company))
                result = _medicineReportModel.GetAllPendingForCompany().ToList();
            else if (User.IsInRole(Role.Pharmacy))
                result = _medicineReportModel.GetAllPendingForPharmacy().ToList();

            return View(result);
        }

        public ActionResult Details(string id)
        {
            _medicineReportModel = new MedicineReportModel(id);
            return View(_medicineReportModel);
        }

        public ActionResult ChangeStatus(string id, EnumMedicineReportStatus status)
        {
            _medicineReportModel.ChangeStatus(id, status);
            return RedirectToAction("Pending");
        }
    }
}