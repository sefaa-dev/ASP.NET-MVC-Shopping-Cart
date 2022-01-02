using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppECartDemo.Models;
using WebAppECartDemo.ViewModel;

namespace WebAppECartDemo.Controllers
{
    public class ShoppingController : Controller
    {
        private ECartDBEntities objECartDbEntities;

        public ShoppingController()
        {
            objECartDbEntities = new ECartDBEntities();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listOfShoppingViewModels = (from objItem in objECartDbEntities.Items
                 join
                 objCate in objECartDbEntities.Categories
                 on objItem.CategoryId equals objCate.CategoryId
                 select new ShoppingViewModel()
                 {
                     ImagePath = objItem.ImagePath,
                     ItemName = objItem.ItemName,
                     Description = objItem.Description,
                     ItemPrice = objItem.ItemPrice,
                     ItemId = objItem.ItemId,
                     Category = objCate.CategoryName,
                     ItemCode = objItem.ItemCode

                 }
                ).ToList();

            return View(listOfShoppingViewModels);
        }
    }
}