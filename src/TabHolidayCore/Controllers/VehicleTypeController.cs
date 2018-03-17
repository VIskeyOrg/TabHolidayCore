using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TabHolidayCore.Controllers
{
    public class VehicleTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}