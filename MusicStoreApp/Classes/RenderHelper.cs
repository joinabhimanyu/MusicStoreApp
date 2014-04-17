using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MusicStoreApp.Classes
{
    public static class RenderHelper
    {
        public static string RenderPartialViewtoString(Controller controller, string view,object model)
        {
            controller.ViewData.Model = model;
            using (System.IO.StringWriter writer=new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, view);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
                viewResult.View.Render(viewContext, writer);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}