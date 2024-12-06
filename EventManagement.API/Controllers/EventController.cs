using EventManagement.BLL.Services.Contracts;
using EventManagement.Model;
using Microsoft.AspNetCore.Mvc;
using EventManagement.API.Utility;
using EventManagement.DTO;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService) : ControllerBase
    {
        
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreationDto model)
        {
            var rsp = new Response<Event>();
            try
            {
                if (model.CreatorUserId <= 0)
                {
                    rsp.status = false;
                    rsp.mesage = "User ID is invalid.";
                    return BadRequest(rsp);
                }

                rsp.status = true;
                rsp.data = await eventService.CreateEvent(model, model.CreatorUserId);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetMyEvents/{userId}")]
        public async Task<IActionResult> GetMyEvents(int userId)
        {
            var rsp = new Response<List<Event>>();
            try
            {
                rsp.status = true;
                rsp.data = await eventService.ListEvents(userId);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var rsp = new Response<List<Event>>();
            try
            {
                rsp.status = true;
                rsp.data = await eventService.GetAllEvents();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }
        
        [HttpGet]
        [Route("GetInvitedPrivateEvents/{userId}")]
        public async Task<IActionResult> GetInvitedPrivateEvents(int userId)
        {
            var rsp = new Response<List<Event>>();
            try
            {
                rsp.status = true;
                rsp.data = await eventService.GetInvitedPrivateEvents(userId);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }
        
        [HttpPost]
        [Route("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentCreationDto model)
        {
            var rsp = new Response<Comment>();
            try
            {
                if (model.EventId <= 0 || model.UserId <= 0)
                {
                    rsp.status = false;
                    rsp.mesage = "Event ID or User ID is invalid.";
                    return BadRequest(rsp);
                }

                rsp.status = true;
                rsp.data = await eventService.AddCommentToEvent(model);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        } 
        
        [HttpGet]
        [Route("GetEventById/{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var rsp = new Response<Event>();
            try
            {
                if (eventId <= 0)
                {
                    rsp.status = false;
                    rsp.mesage = "Event ID inválido.";
                    return BadRequest(rsp);
                }

                rsp.status = true;
                rsp.data = await eventService.GetEventById(eventId);
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