using System;

namespace ReflectionSamples.Basics
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SayHello(string whom)
        {
            Console.WriteLine($"Привет, {whom}");
        }
    }
}
