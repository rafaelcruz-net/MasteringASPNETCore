using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Underwater.Filters;

namespace Underwater.Controllers
{
 
    public class AquariumController : Controller
    {
      
        public AquariumController( )
        {
          
        }

        [LogActionFilter]
        public IActionResult Index()
        {
            return View();
        }

        [LogActionFilter]
        public IActionResult Create()
        {
            return View();
        }
    }
}