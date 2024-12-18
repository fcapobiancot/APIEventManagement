﻿using EventManagement.BLL.Services.Contracts;
using EventManagement.Model;
using Microsoft.AspNetCore.Mvc;
using EventManagement.API.Utility;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

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
    }
}