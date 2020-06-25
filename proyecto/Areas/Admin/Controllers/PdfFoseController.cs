using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class PdfFoseController : Controller
    {
        // GET: Admin/PdfFose
        public ActionResult Index()
        {
            return View();
        }
    }
}