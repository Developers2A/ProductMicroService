﻿using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostGetStateResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public PishroPostObjectsGetState Objects { get; set; }
    }
    /// <summary>
    /// مدل یک استان
    /// <para>no کد استان</para>
    /// <para>name نام استان</para>
    /// 
    /// </summary>
    public class PishroPostState
    {
        public string No { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// مدل لیست استان ها
    /// </summary>
    public class PishroPostObjectsGetState
    {
        public List<PishroPostState> State { get; set; }
    }
}
