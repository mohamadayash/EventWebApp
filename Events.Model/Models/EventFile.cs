using Events.Common.Enums;
using System;

namespace Events.Model.Models
{
    public class EventFile:BaseModel
    {
        public Guid EventRfId { get; set; }
        public string Name { get; set; }
        public FileTypeEnum Type { get; set; }
        public string Path { get; set; }
    }
}