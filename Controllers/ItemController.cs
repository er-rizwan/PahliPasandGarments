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
        private PahliPasandGarmentsEntities objPahliPasandEntities;
        public ItemController()
        {
            objPahliPasandEntities = new PahliPasandGarmentsEntities();
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
            Item objItem = new Item();
            string newImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
            objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + newImage));

            objItem.ImagePath = "~/Images/" + newImage;
            objItem.CategoryId = objItemViewModel.CategoryId;
            objItem.Description = objItemViewModel.Description;
            objItem.ItemCode = objItemViewModel.ItemCode;
            objItem.ItemName = objItemViewModel.ItemName;
            objItem.ItemPrice = objItemViewModel.ItemPrice;
            objItem.ItemId = Guid.NewGuid();
            
            objPahliPasandEntities.Items.Add(objItem);
            objPahliPasandEntities.SaveChanges();

            return Json(new {success=true,Message="Added Successfully!" }, JsonRequestBehavior.AllowGet);
         }
    }
}
