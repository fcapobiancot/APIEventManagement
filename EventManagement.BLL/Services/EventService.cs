using EventManagement.BLL.Services.Contracts;
using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DTO;
using EventManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository<Event> eventRepository;
        private readonly IGenericRepository<Comment> commentRepository;

        public EventService(
            IGenericRepository<Event> eventRepository, 
            IGenericRepository<Comment> commentRepository)
        {
            this.eventRepository = eventRepository;
            this.commentRepository = commentRepository;
        }


        public async Task<List<Event>> ListEvents(int userId)
        {
            try
            {
                var events = await this.eventRepository.Consult(e => e.UserEvents.Any(ue => ue.UserId == userId && ue.IsCreator == true));
                return events.ToList();
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
                    IsActive = true,
                    ImageUrl = eventDto.ImageUrl
                };

                newEvent.UserEvents.Add(new UserEvent
                {
                    UserId = creatorUserId,
                    IsCreator = true,
                    UserMarkAttendance = true,
                    OrganizerMarkAttendance = true,
                    HasPaid = !newEvent.IsPaid 
                });

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

                await eventRepository.CreateAsync(newEvent);

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

        public async Task<List<Event>> GetAllEvents()
        {
            try
            {
                var events = await eventRepository.Consult(e => e.IsPrivate == false);

                // Incluir los comentarios con carga ansiosa
                var eventsWithComments = events
                    .Include(e => e.Comments)
                    .ToList();

                return eventsWithComments;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener eventos: {ex.Message}", ex);
            }
        }
        
        public async Task<List<Event>> GetInvitedPrivateEvents(int userId)
        {
            try
            {
           
                var events = await eventRepository.Consult(e => 
                    e.IsPrivate == true && 
                    e.PrivateEventAccesses.Any(p => p.UserId == userId && p.HasAccess == true)
                );

                return events.ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Comment> AddCommentToEvent(CommentCreationDto commentDto)
        {
            // Verificar si el evento existe
            var existingEvent = await eventRepository.Get(e => e.Id == commentDto.EventId);
            if (existingEvent == null)
            {
                throw new Exception("El evento especificado no existe.");
            }

            // Crear y guardar el comentario
            var newComment = new Comment
            {
                EventId = commentDto.EventId,
                UserId = commentDto.UserId,
                Comment1 = commentDto.Comment1,
                CommentDate = DateTime.UtcNow
            };

            return await commentRepository.CreateAsync(newComment);
        } 
        
        public async Task<Event> GetEventById(int eventId)
        {
            try
            {
                // Buscar el evento por su ID e incluir los comentarios relacionados
                var eventDetails = await eventRepository.Consult(e => e.Id == eventId, e => e.Comments);
                var result = eventDetails.FirstOrDefault();

                if (result == null)
                {
                    throw new Exception("El evento especificado no existe.");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el evento: {ex.Message}", ex);
            }
        }
        
        
    }
}