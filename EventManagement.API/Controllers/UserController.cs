using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EventManagement.BLL.Services.Contracts;
using EventManagement.API.Utility;
using EventManagement.Model;
using EventManagement.DTO;
using EventManagement.BLL.Services;
namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var rsp = new Response<List<UserDTO>>();


            try
            {
                rsp.status = true;
                rsp.data = await userService.ListUsers();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var rsp = new Response<SessionDTO>();


            try
            {
                rsp.status = true;
                rsp.data = await userService.validateCredentials(login.Email, login.Password);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            var rsp = new Response<UserDTO>();

            try
            {
                rsp.status = true;
                rsp.data = await userService.CreateUser(user);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.data = await userService.UpdateUser(user);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.data = await userService.DeleteUser(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

    }
}
