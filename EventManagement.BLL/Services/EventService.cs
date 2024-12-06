using EventManagement.BLL.Services.Contracts;
using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DTO;
using EventManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository<Event> eventRepository;

        public EventService(IGenericRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<List<Event>> ListEvents(int userId)
        {
            try {

                var events = await this.eventRepository.Consult(e => e.UserEvents.Any(ue => ue.UserId == userId && ue.IsCreator == true));

                var userEvents = events.ToList();

                return userEvents;
            }
            catch
            {
                throw;
            }
        }


        public async Task<Event> CreateEvent(EventCreationDto eventDto, int creatorUserId)
        {
            try
            {
                // Crear el evento base
                var newEvent = new Event
                {
                    Name = eventDto.Name,
                    Description = eventDto.Description,
                    StartDate = eventDto.StartDate,
                    Address = eventDto.Address,
                    Capacity = eventDto.Capacity,
                    IsPrivate = eventDto.IsPrivate,
                    IsPaid = eventDto.IsPaid,
                    Price = eventDto.IsPaid ? eventDto.Price : null,
                    Category = eventDto.Category,
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true // Nuevos eventos son activos por defecto
                };

                // Asignar el creador
                newEvent.UserEvents.Add(new UserEvent
                {
                    UserId = creatorUserId,
                    IsCreator = true,
                    UserMarkAttendance = true,
                    OrganizerMarkAttendance = true,
                    HasPaid = !newEvent.IsPaid // Si es gratuito, marcar como pagado
                });

                // Asignar accesos privados si aplica
                if (eventDto.IsPrivate && eventDto.PrivateEventAccessUserIds != null)
                {
                    foreach (var userId in eventDto.PrivateEventAccessUserIds)
                    {
                        newEvent.PrivateEventAccesses.Add(new PrivateEventAccess
                        {
                            UserId = userId,
                            HasAccess = true
                        });
                    }
                }

                // Guardar el evento en la base de datos
                await eventRepository.CreateAsync(newEvent);

                // Consultar el evento creado para incluir navegaciones
                var query = await eventRepository.Consult(u => u.Id == newEvent.Id);
                var eventWithCategory = query
                    .Include(cat => cat.CategoryNavigation)
                    .FirstOrDefault();

                return eventWithCategory ?? throw new Exception("Event creation failed.");
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No additional details.";
                throw new Exception($"Error creating event: {ex.Message}. Details: {innerException}");
            }
        }


    }
}
