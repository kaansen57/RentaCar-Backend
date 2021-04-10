using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTO_s;
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
    public class UserController : ControllerBase
    {
        private readonly IUserJwtManager _userJwtManager;

        public UserController(IUserJwtManager userJwtManager)
        {
            _userJwtManager = userJwtManager;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userJwtManager.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userJwtManager.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userJwtManager.GetUser(email);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(UserJWT user)
        {
            var result = _userJwtManager.Update(user);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserJWT user)
        {
            var result = _userJwtManager.Delete(user);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

