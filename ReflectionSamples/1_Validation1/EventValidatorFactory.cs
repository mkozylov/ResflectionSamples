using System;

namespace ReflectionSamples.Validation1
{
    public class EventValidatorFactory
    {
        private const string _ns = "ReflectionSamples.Validation1";

        public IEventValidator Create(EventTypes eventType)
        {
            //Получаем тип валидатора по его имени
            var validatorType = Type.GetType($"{_ns}.{eventType}Validation", true);

            //создаем экземпляр валидатора
            return (IEventValidator)Activator.CreateInstance(validatorType);
        }
    }
}
