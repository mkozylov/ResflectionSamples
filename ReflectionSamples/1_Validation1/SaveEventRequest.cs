using System;

namespace ReflectionSamples.Validation1
{
    public class SaveEventRequest
    {
        public EventTypes EventCode { get; set; } 

        public string Phone { get; set; }

        public Guid? UserId { get; set; }

        public string Email { get; set; }

        public Guid? CompanyId { get; set; }
    }
}
