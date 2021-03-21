using System.ComponentModel.DataAnnotations;

namespace ReflectionSamples.Enums
{
    public enum JobTypes
    {
        [Display(Name = "Погрузка")]
        Loading,

        [Display(Name = "Выгрузка")]
        Unloading,

        [Display(Name = "Погрузка/Выгрузка")]
        Any
    }
}
