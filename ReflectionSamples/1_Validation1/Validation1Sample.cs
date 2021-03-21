using System;

namespace ReflectionSamples.Validation1
{
    public class Validation1Sample
    {
        public void Run()
        {
            //создали фабрику валидаторов событий
            var factory = new EventValidatorFactory();

            //создали экземпляр события
            var request = new SaveEventRequest
            {
                EventCode = EventTypes.Login,
                UserId = Guid.NewGuid()
            };

            //получаем валидатор по коду события
            var validator = factory.Create(request.EventCode);

            //производим валидацию модели
            if (validator.Validate(request, out var errors))
            {
                //действие в случае валидности модели
            }
            else
            {
                //действие при невалидной модели
            }
        }
    }
}
