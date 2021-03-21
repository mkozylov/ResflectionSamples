using ReflectionSamples.Plugins.Abstracts;
using System;

namespace ReflectionSamples.Plugins
{
    public class SimplePlugin
        : IPlugin
    {
        public void Print()
        {
            Console.WriteLine("Привет из плагина");
        }
    }
}
