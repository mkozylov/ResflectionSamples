using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ReflectionSamples.Embedded
{
    public class EmbeddedSample
    {
        public void Run()
        {
            //Получаем сборку приложения
            var assembly = Assembly.GetEntryAssembly();

            //получаем полное имя ресурса
            var resourceName = assembly.GetManifestResourceNames()
                                       .First(x => x.EndsWith("EmbeddedResource.html"));

            Console.WriteLine($"Ресурс: {resourceName}");

            //получили поток данных ресурса
            using var stream = assembly.GetManifestResourceStream(resourceName);

            using var streamReader = new StreamReader(stream);

            //считали контент ресурса
            var resourceContent = streamReader.ReadToEnd();

            Console.WriteLine($"Контент: {resourceContent}");

            //вывод
            /*
            Ресурс: ReflectionSamples.Embedded.EmbeddedResource.txt
            Контент: Lorem ipsum dolor sit amet, consectetur adipiscing elit.
            */
        }
    }
}
