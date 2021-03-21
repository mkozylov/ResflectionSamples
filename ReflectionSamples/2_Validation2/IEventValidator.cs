using System.Collections.Generic;

namespace ReflectionSamples.Validation2
{
    public interface IEventValidator
    {
        EventTypes Type { get; }

        bool Validate(
            SaveEventRequest request, 
            out string[] errors
            );
    }
}
