using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionSamples.DictionaryFactory
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Кеш делегатов фабрик словарей
        /// </summary>
        private static DictionaryFactoryCollection _dictionaryFactories = new DictionaryFactoryCollection();

        /// <summary>
        /// Создание словаря свойств на основании экземпляра объекта
        /// </summary>
        /// <param name="source">Экземпляр объекта</param>
        /// <returns>Словарь свойств объекта</returns>
        public static Dictionary<string, object> ToSet(this object source)
        {
            //получаем или создаем фабрику для словаря свойств объекта на основании его типа
            var factory = _dictionaryFactories.GetOrAdd(source.GetType(), t =>
            {
                var factoryDelegate = typeof(PropertyCache<>)
                    .MakeGenericType(t)
                    .GetMethod("ToObjectDictionary", BindingFlags.Public | BindingFlags.Static)
                    .CreateDelegate(
                        typeof(Func<object, Dictionary<string, object>>)
                        );

                return (Func<object, Dictionary<string, object>>)factoryDelegate;
            });

            //создаем словарь со свойствами и их значениями
            var dictionary = factory(source);

            return dictionary;
        }

        #region Internal

        /// <summary>
        /// Кеш свойств типа объекта
        /// </summary>
        /// <typeparam name="TSource">Тип экземпляра объекта</typeparam>
        private static class PropertyCache<TSource>
        {
            private static PropertyInfo[] _members;

            static PropertyCache()
            {
                _members = typeof(TSource).GetProperties();
            }

            public static Dictionary<string, object> ToObjectDictionary(object obj)
            {
                return _members.ToDictionary(
                    k => k.Name,
                    v => v.GetValue(obj)
                    );
            }
        }

        /// <summary>
        /// Кеш коллекции фабрик словарей свойств объектов
        /// </summary>
        private class DictionaryFactoryCollection
            : ConcurrentDictionary<Type, Func<object, Dictionary<string, object>>>
        {
        }

        #endregion
    }
}