using Events.Model.Models;
using Events.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EventsWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {


        private readonly ILogger<EventsController> _logger;
        private readonly EventService eventService;
        private string storage = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/files/";

        public EventsController(ILogger<EventsController> logger,EventService eventService)
        {
            _logger = logger;
            this.eventService = eventService;
        }

        [HttpGet()]
        public IEnumerable<Event> GetEvents()
        {
              return this.eventService.GetEvents();
        }

        [HttpPost()]
        public async Task<IActionResult> PostEvent([FromForm] string eventTitle, [FromForm] string eventDate,[FromForm] IFormFileCollection files)
        {
            var e = new Event();

            e.RfId = Guid.NewGuid();
            e.Title = eventTitle;
            e.EventDate = DateTime.UtcNow;
            e.CreationDate = DateTime.UtcNow;

            e.Files = new List<EventFile>();

            //create event directory
            string eventDirectory = $"{storage}/{e.RfId.ToString()}";
            if (!Directory.Exists(eventDirectory))
            {
                Directory.CreateDirectory(eventDirectory);
            }
            
            foreach(var file in files)
            {
                var eventFile = new EventFile();
                eventFile.RfId = Guid.NewGuid();
                eventFile.Name = file.FileName;
                eventFile.Path = $"{e.RfId.ToString()}/{eventFile.RfId.ToString()}";
                
                //save file to storage
                using (FileStream fileStream = new FileStream($"{eventDirectory}/{eventFile.RfId.ToString()}", FileMode.CreateNew, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }


                e.Files.Add(eventFile);
            }

            //save to db 
            if (await this.eventService.InsertEvent(e) == true)
            {
                await this.eventService.InsertEventFiles(e.Files);
            }


        
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateEvent([FromForm] Guid eventRfId,[FromForm] string eventTitle, [FromForm] string eventDate, [FromForm] IFormFileCollection files)
        {
            var e = new Event();

            e.RfId = eventRfId;
            e.Title = eventTitle;
            e.EventDate = DateTime.UtcNow;
            e.CreationDate = DateTime.UtcNow;

            e.Files = new List<EventFile>();

            //create event directory
            string eventDirectory = $"{storage}/{e.RfId.ToString()}";
            if (!Directory.Exists(eventDirectory))
            {
                Directory.CreateDirectory(eventDirectory);
            }

            foreach (var file in files)
            {
                var eventFile = new EventFile();
                eventFile.RfId = Guid.NewGuid();
                eventFile.Name = file.FileName;
                eventFile.Path = $"{e.RfId.ToString()}/{eventFile.RfId.ToString()}";

                //save file to storage
                using (FileStream fileStream = new FileStream($"{eventDirectory}/{eventFile.RfId.ToString()}", FileMode.CreateNew, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }


                e.Files.Add(eventFile);
            }

            //save to db 
            if (await this.eventService.UpdateEvent(e) == true)
            {
                await this.eventService.InsertEventFiles(e.Files);
            }



            return Ok();
        }

    }
}