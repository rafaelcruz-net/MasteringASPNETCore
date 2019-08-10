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
using Underwater.Models;
using Underwater.Repositories;

namespace Underwater.Controllers
{
 
    public class AquariumController : Controller
    {
        private IUnderwaterRepository Repository { get; set; }

        public AquariumController(IUnderwaterRepository repository)
        {
            this.Repository = repository;
        }

        [LogActionFilter]
        public IActionResult Index()
        {
            return View(this.Repository.Getfishes());
        }

        [LogActionFilter]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Fish model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View();

        }
    }
}