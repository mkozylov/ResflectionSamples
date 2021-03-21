using System.Collections.Generic;

namespace ReflectionSamples.Validation1
{
    public interface IEventValidator
    {
        bool Validate(
            SaveEventRequest request, 
            out string[] errors
            );
    }
}
