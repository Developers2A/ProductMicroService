using System.ComponentModel;

namespace Product.Domain.Enums
{
    public enum CityType
    {
        [Description("تهران")] Tehran = 1,
        [Description(" کلانشهرها-جی 8")] G8 = 2,
        [Description("مرکز استان")] StateCenter = 3,
        [Description("شهرستان ها")] SmallCities = 4
    }
}