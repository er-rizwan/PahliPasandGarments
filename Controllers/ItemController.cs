using PahliPasandGarments.Models;
using PahliPasandGarments.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PahliPasandGarments.Controllers
{
    public class ItemController : Controller
    {
        private PahliPasandEntities objPahliPasandEntities;
        public ItemController()
        {
            objPahliPasandEntities = new PahliPasandEntities();
        }
        // GET: Item
        public ActionResult Index()
        {
           ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objPahliPasandEntities.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.CategoryName,
                                                           Value = objCat.CategoryId.ToString(),
                                                           Selected = true
                                                       });
            return View(objItemViewModel);
        }

        [HttpPost]
        public JsonResult Index(ItemViewModel objItemViewModel)
        {
            string newImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
            objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + newImage));
            return Json(data:objItemViewModel.ItemPrice, JsonRequestBehavior.AllowGet);
         }
    }
}
