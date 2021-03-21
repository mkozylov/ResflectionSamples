using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ReflectionSamples.DictionaryFactory
{
    public class DictionaryFactorySample
    {
        public void Run()
        {
            //создаем тестовые модели
            var model2 = new Model2
            {
                MyProperty = 2
            };

            var model1 = new Model1 
            {
                IntProp = 1,
                StringProp = "str",
                BoolProp = true,
                Model2Prop = model2
            };

            var model3 = new { Name = "test" };

            //выводим модель 1 в виде json объекта
            Dictionary<string, object> model1Set = model1.ToSet();
            var model1Json = JsonConvert.SerializeObject(model1Set, Formatting.Indented);
            Console.WriteLine(model1Json);
            Console.WriteLine();

            //выводим модель 2 в виде json объекта
            Dictionary<string, object> model2Set = model2.ToSet();
            var model2Json = JsonConvert.SerializeObject(model2Set, Formatting.Indented);
            Console.WriteLine(model2Json);
            Console.WriteLine();

            //выводим модель 3 в виде json объекта
            Dictionary<string, object> model3Set = model3.ToSet();
            var model3Json = JsonConvert.SerializeObject(model3Set, Formatting.Indented);
            Console.WriteLine(model3Json);

            //вывод
            /*
            {
              "IntProp": 1,
              "StringProp": "str",
              "BoolProp": true,
              "Model2Prop": {
                "MyProperty": 2
              }
            }

            {
              "MyProperty": 2
            }

            {
              "Name": "test"
            }
            */
        }
    }
}
