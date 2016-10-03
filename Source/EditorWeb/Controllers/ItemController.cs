using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cognitio.Model;


namespace Cognitio.EditorWeb.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {

            List<Item> builtItems = ItemFactory.GetItems();



            

            return View(builtItems);
        }

        
    }
}