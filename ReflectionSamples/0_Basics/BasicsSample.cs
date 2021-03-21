using System;
using System.Linq;
using System.Reflection;

namespace ReflectionSamples.Basics
{
    public class BasicsSample
    {
        public void Run()
        {
            ReadAssemblyInfo();

            ReadTypeInfo();

            ReadObjectSample();

            WriteObjectSample();

            CallMethodSample();

            CreateObjectSample();
        }

        #region Internal

        private void ReadAssemblyInfo()
        {
            //получили текущую сборку
            var assembly = Assembly.GetEntryAssembly();
            //получили краткую информацию о сборке
            var assemblyInfo = assembly.GetName();

            Console.WriteLine($"Имя сброки: {assemblyInfo.Name}");
            Console.WriteLine($"Версия сборки: {assemblyInfo.Version}");

            //публичные типы сборки в текущем пространстве имен
            var currentNameTypes = assembly.ExportedTypes
                .Where(x => x.Namespace == typeof(BasicsSample).Namespace);

            Console.WriteLine("Типы пространстве имен 'ReflectionSamples.Basics':");

            foreach (var type in currentNameTypes)
            {
                Console.WriteLine(type.Name);
            }
        }

        public void ReadTypeInfo()
        {
            //получили тип класса
            var personType = typeof(Person);

            //получили публичные свойства
            var properties = personType.GetProperties();
            //получили публичные поля
            var fields = personType.GetFields();
            //получили публичные методы
            var methods = personType.GetMethods();
            //получили атрибуты
            var attributes = personType.GetCustomAttributes();

            Console.WriteLine($"Имя типа: {personType.Name}");
            Console.WriteLine($"Пространство имен: {personType.Namespace}");

            //вывод
            /*
            Имя типа: Person
            Пространство имен: Person
            */
        }

        private void ReadObjectSample()
        {
            //создаем экземпляр класса
            var person = new Person
            {
                Name = "Иван",
                Age = 18
            };

            //получаем тип объекта из его экземпляра
            var personType = person.GetType();

            Console.WriteLine($"Имя типа: {personType.Name}");
            Console.WriteLine("Свойства:");

            foreach (var property in personType.GetProperties())
            {
                var name = property.Name;
                var typeName = property.PropertyType.Name;
                var value = property.GetValue(person);

                Console.WriteLine($" {name} ({typeName}) = {value}");
            }

            //вывод
            /*
            Имя типа: Person
            Свойства:
             Name (String) = Иван
             Age (Int32) = 18
            */
        }

        private void WriteObjectSample()
        {
            var person = new Person
            {
                Name = "Иван",
                Age = 18
            };

            var personType = person.GetType();

            var nameProp = personType.GetProperty("Name");

            nameProp.SetValue(person, "Петр");

            var ageProp = personType.GetProperty("Age");

            ageProp.SetValue(person, 20);

            Console.WriteLine($"Имя: {person.Name}");
            Console.WriteLine($"Полных лет: {person.Age}");

            //вывод
            /*
            Имя: Петр
            Полных лет: 20
            */
        }

        private void CallMethodSample()
        {
            var person = new Person
            {
                Name = "Иван",
                Age = 18
            };

            var personType = person.GetType();

            var helloMethod = personType.GetMethod("SayHello");

            helloMethod.Invoke(person, new[] { "всем" });

            //вывод
            /*
            Привет, всем
            */
        }

        private void CreateObjectSample()
        {
            var person1 = System.Activator.CreateInstance<Person>();

            var person2 = System.Activator.CreateInstance(typeof(Person));

            var person3 = System.Activator.CreateInstance(typeof(Person), "Иван", 18);
        }

        #endregion
    }
}
