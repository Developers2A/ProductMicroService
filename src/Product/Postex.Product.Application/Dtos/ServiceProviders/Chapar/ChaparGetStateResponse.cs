using System.Collections.Generic;

namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar
{
    public class ChaparGetStateResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsGetState Objects { get; set; }
    }
    /// <summary>
    /// مدل یک استان
    /// <para>no کد استان</para>
    /// <para>name نام استان</para>
    /// 
    /// </summary>
    public class ChaparState
    {
        public string No { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// مدل لیست استان ها
    /// </summary>
    public class ObjectsGetState
    {
        public List<ChaparState> State { get; set; }
    }
}
