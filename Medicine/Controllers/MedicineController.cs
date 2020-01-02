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
        public ActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = Role.NormalUser)]
        public ActionResult Report(string id)
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