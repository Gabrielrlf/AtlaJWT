using AtlaJWT.Domain.Entities;
using AtlaJWT.Domain.Exception;
using AtlaJWT.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlaJWT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [Authorize(Roles = "Admin")]
        [HttpGet, Route("GetAll")]
        public async Task<ActionResult<UserRegistered>> GetAllRegistered()
        {
            try
            {
                var result = await _userService.GetAllUserRegistered();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e) { StatusCode = 405, Value = e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Remove/{id}")]
        public async Task<ActionResult<bool>> RemoveUser(int id)
        {
            try
            {
                var result = await _userService.RemoveUser(id);
                return Ok(new JsonResult(result) { StatusCode = 200, Value = "Usuário excluído com sucesso!" });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e) { StatusCode = 405, Value = e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> CreateRegister([FromBody] UserRegistered userRegistered)
        {
            try
            {
                var result = await _userService.CreateUserRegistered(userRegistered);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e) { StatusCode = 405, Value = e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Update")]
        public async Task<ActionResult<UserToken>> UpdateRegister([FromBody] UserRegistered userRegistered)
        {
            try
            {
                var result = await _userService.UpdateUserRegistered(userRegistered);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e) { StatusCode = 405, Value = e.Message });
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            try
            {
                userInfo.IsValid(userInfo);
                var result = await _userService.Login(userInfo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e) { StatusCode = 405, Value = e.Message });
            }
        }

    }
}
