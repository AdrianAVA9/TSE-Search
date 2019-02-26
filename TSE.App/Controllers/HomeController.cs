using System;
using System.Web.Mvc;
using TSE.App.Core;
using TSE.App.Core.Models;
using TSE.App.Persistance;

namespace TSE.App.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfwork { get; set; }

        public HomeController()
        {
            _unitOfwork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchById()
        {
            return View();
        }

        public ActionResult SearchByIdUsingLinq()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProfile(string id)
        {
            var profileId = id?.Replace("-", "");

            if (string.IsNullOrEmpty(id) && profileId?.Length != 10) return Json(null,JsonRequestBehavior.AllowGet);

            var profile = _unitOfwork.Profiles.GetProfile(profileId);

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(profile),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProfile_Linq(string id)
        {
            var profileId = id?.Replace("-", "");

            if (string.IsNullOrEmpty(id) && profileId?.Length != 10) return Json(null, JsonRequestBehavior.AllowGet);

            var profile = _unitOfwork.Profiles.GetProfile_Linq(profileId);

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(profile),
                JsonRequestBehavior.AllowGet);
        }
    }
}