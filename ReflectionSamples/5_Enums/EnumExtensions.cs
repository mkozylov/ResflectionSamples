using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReflectionSamples.Enums
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum source)
        {
            //получили тип перечисления
            var enumType = source.GetType();

            //получили из типа поле перечисления по его имени
            var member = enumType.GetField(source.ToString());

            //получили экземпляр атрибута DisplayAttribute из поля перечисления
            var attr = (DisplayAttribute)member.GetCustomAttributes(typeof(DisplayAttribute), false)
                                               .FirstOrDefault();

            //получили из атрибута указанное в нем имя
            return attr?.Name;
        }
    }
}
