using EventManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BLL.Services.Contracts
{
    public interface IEventService
    {
        Task<List<Event>> ListEvents(int userId);
        Task<Event> CreateEvent(EventCreationDto eventDto, int creatorUserId);
        Task<List<Event>> GetAllEvents();
        
    }
}
