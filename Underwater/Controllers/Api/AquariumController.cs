using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Underwater.Repositories;

namespace Underwater.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AquariumController : ControllerBase
    {
        private IUnderwaterRepository Repository { get; set; }

        public AquariumController(IUnderwaterRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet("")]
        public IActionResult GetAquarium()
        {
            return Ok(this.Repository.GetAquarium());

        }

        [HttpGet("{id}")]
        public IActionResult GetAquarium(int id)
        {
            return Ok(this.Repository.GetAquarium(id));
        }


    }
}