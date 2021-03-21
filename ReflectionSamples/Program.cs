using ReflectionSamples.Basics;
using ReflectionSamples.DictionaryFactory;
using ReflectionSamples.Embedded;
using ReflectionSamples.Enums;
using ReflectionSamples.Plugin;
using ReflectionSamples.Validation1;
using ReflectionSamples.Validation2;

namespace ReflectionSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            new BasicsSample().Run();

            new Validation1Sample().Run();

            new Validation2Sample().Run();

            new PluginSample().Run();

            new EmbeddedSample().Run();

            new EnumsSample().Run();

            new DictionaryFactorySample().Run();
        }
    }
}
