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
	public class ItemViewmodel
	{
		public ItemTypeObject rootItem { get; set; }
	}
	
    public class ItemController : Controller
    {
        public ActionResult Index()
        {          
            ItemManager.CreateItemGroup();
			
			// get root object (pass in null)
			ItemTypeObject rootItem = ItemManager.GetItemTypeObject(null);

            //ItemObjectList a = new ItemObjectList { rootItem };
            return View(rootItem);
        }

        public ActionResult FoodList()
        {

            ItemManager.GetItemGroup();





            return View();
        }
        
    }
}