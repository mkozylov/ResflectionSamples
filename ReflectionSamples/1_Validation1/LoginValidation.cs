using System.Collections.Generic;

namespace ReflectionSamples.Validation1
{
    public class LoginValidation
         : IEventValidator
    {
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
