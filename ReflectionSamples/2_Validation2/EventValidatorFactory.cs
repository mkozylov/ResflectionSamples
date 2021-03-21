using System.Collections.Generic;

namespace ReflectionSamples.Validation2
{
    public class EventValidatorFactory
    {
        private readonly Dictionary<EventTypes, IEventValidator> _validators;

        public EventValidatorFactory(Dictionary<EventTypes, IEventValidator> validators)
        {
            _validators = validators;
        }

        public IEventValidator Create(EventTypes eventType)
        {
            return _validators[eventType];
        }
    }
}
