using System;
using System.Collections.Generic;

namespace Events.Model.Models
{
    public class Event:BaseModel
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EventDate { get; set; }
        public virtual List<EventFile> Files { get; set; }
    }
}