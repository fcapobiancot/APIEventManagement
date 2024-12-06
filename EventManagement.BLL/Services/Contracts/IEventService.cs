using EventManagement.DTO;
using EventManagement.Model;
namespace EventManagement.BLL.Services.Contracts
{
    public interface IEventService
    {
        Task<List<Event>> ListEvents(int userId);
        Task<Event> CreateEvent(EventCreationDto eventDto, int creatorUserId);
        Task<List<Event>> GetAllEvents();
        Task<List<Event>> GetInvitedPrivateEvents(int userId);
        
        Task<Comment> AddCommentToEvent(CommentCreationDto commentDto); 
        
        Task<Event> GetEventById(int eventId);
    }
}