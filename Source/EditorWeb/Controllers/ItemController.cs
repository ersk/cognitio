using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cognitio.Model;
using Cognitio.Model.Object;
using Cognitio.Model.Group;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Cognitio.Model.Object;


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
            //ItemManager.CreateItemGroup();
			
			// get root object (pass in null)
			ItemTypeObject rootItem = ItemManager.GetItemTypeObject(null);

            //ItemObjectList a = new ItemObjectList { rootItem };
            return View(rootItem);
        }

        [HttpPost]
        public JsonResult AddItem(AddItemTypeAjaxModel ajaxModel)
        {

            

            string controllerModelTypeStr = "Cognitio.EditorWeb.Controllers.ItemController+" + ajaxModel.ModelType;
            Type controllerModelType = Type.GetType(controllerModelTypeStr);
            //var controllerModel = Convert.ChangeType(ajaxModel.ControllerModel, controllerModelType);
            var controllerModel = JsonConvert.DeserializeObject(ajaxModel.ControllerModel, controllerModelType);

            string ajaxModelTypeStr = "Cognitio.Model.Object.ItemManager+" 
                + ajaxModel.ModelType.Replace("Controller", "Manager")
                + ", Cognitio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type managerModelType = Type.GetType(ajaxModelTypeStr);
            ConstructorInfo managerModelCtor = managerModelType.GetConstructor(Type.EmptyTypes);
            var managerModel = managerModelCtor.Invoke(new object[] { });

            PropertyInfo pi2;
            object valObject;
            foreach(PropertyInfo pi in controllerModelType.GetProperties())
            {
                valObject = pi.GetValue(controllerModel);

                pi2 = managerModelType.GetProperty(pi.Name);
                if(pi2.PropertyType == typeof(uint))
                {
                    pi2.SetValue(managerModel, Convert.ToUInt32(valObject));
                }
                else
                {
                    pi2.SetValue(managerModel, valObject);
                }
                    
            }

            //string itemManagerTypeStr = "Cognitio.Model.Object.ItemManager";
            //Type itemManagerType = Type.GetType(itemManagerTypeStr);
            //var managerModel = managerModelType.GetConstructor(null);
            Type itemManagerType = typeof(ItemManager);

            MethodInfo addItemMethod = itemManagerType.GetMethod("AddItem", new Type[] { managerModelType });
            addItemMethod.Invoke(null, new object[] { managerModel } );

            //ItemManager.AddItem(Convert.ChangeType(managerModel, managerModelType));

            return Json(new { ResultStatus = "Success" });
        }

        public class AddItemTypeAjaxModel
        {
            public string ModelType { get; set; }
            public string ControllerModel { get; set; }
        }

        public class AddItemTypeControllerModel
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }
        public class AddItemControllerModel : AddItemTypeControllerModel
        {
            public string Weight { get; set; }
            public string Size { get; set; }
        }
        public class AddFoodItemControllerModel : AddItemControllerModel
        {
            public string FoodValue { get; set; }
        }
        
    }
}