using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cognitio.Model;
using Cognitio.Model.Object;
using Cognitio.Model.Group;


namespace Cognitio.EditorWeb.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {

          
            ItemManager.CreateItemGroup();
            

            return View();
        }

        public ActionResult FoodList()
        {

            ItemManager.GetItemGroup();





            return View();
        }
        
    }
}