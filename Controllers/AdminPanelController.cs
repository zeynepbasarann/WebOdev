using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class AdminPanelController : Controller
    {
        private readonly VbContext _vbcontext;

        public AdminPanelController()
        {
            _vbcontext = new VbContext();
        }

        public ActionResult Admin()
        {
            
            return View();
        }
    }
}