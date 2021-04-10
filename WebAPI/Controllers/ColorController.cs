using Business.Abstract;
using Entities.Concrete;
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
    public class ColorController : ControllerBase
    {
        private IColorManager _colorManager;
        public ColorController(IColorManager colorManager)
        {
            _colorManager = colorManager;
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorManager.Add(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorManager.Delete(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorManager.Update(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorManager.GetAllList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _colorManager.GetColor(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
