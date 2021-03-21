using System.Collections.Generic;

namespace ReflectionSamples.Validation2
{
    public class LoginValidation
         : IEventValidator
    {
        public EventTypes Type { get; } = EventTypes.Login;

        public bool Validate(
            SaveEventRequest request,
            out string[] errors
            )
        {
            var errorsList = new List<string>();

            if (request.UserId == null)
            {
                errorsList.Add("UserId is null");
            }

            errors = errorsList.ToArray();

            return errorsList.Count == 0;
        }
    }
}
