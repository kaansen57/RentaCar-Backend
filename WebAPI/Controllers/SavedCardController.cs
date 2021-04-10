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
    public class SavedCardController : ControllerBase
    {
        private ISavedCardManager _savedCardManager;
        public SavedCardController(ISavedCardManager savedCardManager)
        {
            _savedCardManager = savedCardManager;
        }

        [HttpPost("add")]
        public IActionResult Add(SavedCard creditCard)
        {
           var result =  _savedCardManager.Add(creditCard);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _savedCardManager.GetUserCreditCard(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _savedCardManager.GetAllList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
