using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ReflectionSamples.Validation2
{
    public class Validation2Sample
    {
        public void Run()
        {
            //регистрируем зависимости, получаем поставщик сервисов
            var injector = BuildServiceProvider();

            //создали фабрику валидаторов событий
            var factory = injector.GetRequiredService<EventValidatorFactory>();

            //создали эземпляр события
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

        #region Internal

        private ServiceProvider BuildServiceProvider()
        {
            //получили пространство имен для текущего класса
            var currentNs = GetType().Namespace;

            var services = new ServiceCollection();

            //получаем типы валидаторов находящиеся в том же пространстве имен что и текущий класс 
            //а так же реализующие интерфейс IEventValidator
            var validatorTypes = Assembly.GetEntryAssembly()
                                    .ExportedTypes
                                    .Where(t =>
                                        t.Namespace == currentNs
                                        && t.GetInterface(nameof(IEventValidator)) != null
                                        )
                                    .ToArray();

            //регистрируем найденые типы в контейнере
            foreach (var type in validatorTypes)
            {
                services.AddSingleton(type);
            }

            //регистрируем словарь валидаторов на основании уже найденых 
            //и зарегистрированных в контейнере типов валидаторов
            services.AddSingleton<Dictionary<EventTypes, IEventValidator>>(
                s => validatorTypes.Select(t => (IEventValidator)s.GetService(t))
                                   .ToDictionary(k => k.Type, v => v)
                );

            //регистрируем фабрику валидаторов событий
            services.AddSingleton<EventValidatorFactory>();

            var injector = services.BuildServiceProvider();

            return injector;
        } 

        #endregion
    }
}
