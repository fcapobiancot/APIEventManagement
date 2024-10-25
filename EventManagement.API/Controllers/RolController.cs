using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EventManagement.BLL.Services.Contracts;
using EventManagement.API.Utility;
using EventManagement.Model;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService rolService;

        public RolController(IRolService rolService)
        {
            this.rolService = rolService;
        }

        [HttpGet]
        [Route("RolesList")]
        public async Task<IActionResult> RolesList()
        {
            var rsp = new Response<List<Rol>>();


            try
            {
                rsp.status = true;
                rsp.data = await rolService.List();
                
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
