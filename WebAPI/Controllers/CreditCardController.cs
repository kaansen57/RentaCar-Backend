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
    public class CreditCardController : ControllerBase
    {
        private ICreditCardManager _creditCardManager;
        public CreditCardController(ICreditCardManager creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }
        [HttpPost("cardadd")]
        public IActionResult CreditCardAdd([FromForm]CreditCard creditCard)
        {
            var result = _creditCardManager.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("cardDelete")]
        public IActionResult CreditCardDelete([FromForm] CreditCard creditCard)
        {
            var result = _creditCardManager.Delete(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("cardUpdate")]
        public IActionResult CreditCardUpdate([FromForm] CreditCard creditCard)
        {
            var result = _creditCardManager.Update(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getcardall")]
        public IActionResult CreditCardAll()
        {
            var result = _creditCardManager.GetAllList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getcardbyid")]
        public IActionResult CreditCardById(int id)
        {
            var result = _creditCardManager.GetCreditCard(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost("cardcheck")]
        public IActionResult CreditCardCheck(CreditCard creditCard)
        {
            var result = _creditCardManager.CreditCardChecker(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
