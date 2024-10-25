using EventManagement.DAL;
using EventManagement.DAL.DBContext;
using EventManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManagement.API.Controllers
{
    public class EventCon
    {
        public string? Name { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseTestController : ControllerBase
    {
        private readonly EventManagementContext _context;

        public DatabaseTestController(EventManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EventCon> TestDatabaseConnection()
        {
            try
            {
                // Realizamos una consulta sencilla a la tabla de usuarios
                var users = _context.Users.ToList();

                var events = _context.Events.ToList();

                // Imprimimos en la consola de Visual Studio
                Console.WriteLine("Número de usuarios: " + users.Count);

                // Devolvemos el resultado como respuesta de la API

                return Enumerable.Range(1, 5).Select(index => new EventCon
                {
                    Name = users[index].Name
                }).ToArray();
            }
            catch (Exception ex)
            { 
                // Si hay un error, lo mostramos en la terminal y devolvemos un código 500
                throw;

            }
        }
    }
}
