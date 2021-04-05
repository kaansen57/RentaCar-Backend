using Business.Abstract;
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
    public class RentalTermController : ControllerBase
    {
        private IRentalTermManager _rentalTermManager;  
        public RentalTermController(IRentalTermManager rentalTermManager)
        {
            _rentalTermManager = rentalTermManager;
        }

        [HttpGet("getbyid")]
        public IActionResult GetRentalTerm(int carId)
        {
            var result = _rentalTermManager.GetRentalTerm(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
            
        }

        [HttpGet("getall")]
        public IActionResult GetRentalTermAll()
        {
            var result = _rentalTermManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
