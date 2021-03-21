using System;

namespace ReflectionSamples.Enums
{
    public class EnumsSample
    {
        public void Run()
        {
            var loadingJobType = JobTypes.Loading;
            var unloadingJobType = JobTypes.Unloading;
            var anyJobType = JobTypes.Any;

            Console.WriteLine($"{JobTypes.Loading}: {loadingJobType.DisplayName()}");
            Console.WriteLine($"{JobTypes.Unloading}: {unloadingJobType.DisplayName()}");
            Console.WriteLine($"{JobTypes.Any}: {anyJobType.DisplayName()}");

            //вывод
            /*
            Loading: Погрузка
            Unloading: Выгрузка
            Any: Погрузка/Выгрузка
            */
        }
    }
}
