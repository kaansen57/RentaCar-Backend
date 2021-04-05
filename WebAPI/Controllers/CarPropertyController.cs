using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPropertyController : ControllerBase
    {
        private ICarPropertyManager _carPropertyManager;

        public CarPropertyController(ICarPropertyManager carPropertyManager)
        {
            _carPropertyManager = carPropertyManager;
        }

        [CacheAspect]
        [HttpGet("details")]
        public IActionResult GetAllDetail()
        {
            var result = _carPropertyManager.GetAllPropertyDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [CacheAspect]
        [HttpGet("detailsbyid")]
        public IActionResult GetDetailId(int propId)
        {
            var result = _carPropertyManager.GetPropertyDetail(propId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
