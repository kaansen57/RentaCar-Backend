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
    public class OperationClaimController : ControllerBase
    {
        private IOperationClaimManager _operationClaimManager;
        public OperationClaimController(IOperationClaimManager operationClaimManager)
        {
            _operationClaimManager = operationClaimManager;
        }

        [HttpGet("getall")]
        public IActionResult OperationClaimGetAll()
        {
            var result  = _operationClaimManager.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
