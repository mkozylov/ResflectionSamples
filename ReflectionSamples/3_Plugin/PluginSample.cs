using ReflectionSamples.Plugins.Abstracts;
using System;
using System.Linq;
using System.Reflection;

namespace ReflectionSamples.Plugin
{
    public class PluginSample
    {
        public void Run()
        {
            //загружаем сборку с плагином
            var pluginAssembly = Assembly.LoadFrom("ReflectionSamples.Plugins.dll");

            //получаем тип плагина который реализует интерфейс IPlugin
            var pluginType = pluginAssembly.ExportedTypes
                                           .First(t => t.GetInterface(nameof(IPlugin)) != null);

            Console.WriteLine($"Имя типа плагина: {pluginType.Name}");

            //создаем экземпляр плагина
            var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);

            //вызываем метод печати плагина
            pluginInstance.Print();

            //вывод
            /*
            Имя типа плагина: SimplePlugin
            Привет из плагина
            */
        }
    }
}
