﻿using Product.Application.Dtos.CollectionDistributions;

namespace ParcelPriceCalculatorPaykhub.Helper
{
    public static class BoxSizeHelper
    {
        //public static double GetVolume(this BoxSize boxSize)
        //{
        //	return boxSize.Height * boxSize.Length * boxSize.Width;
        //}
        public static double GetVolume(this ParcelPrice boxPrice)
        {
            return boxPrice.Height * boxPrice.Length * boxPrice.Width;
        }

        //public static double GetArea(this BoxSize boxSize)
        //{
        //	return 2 * ((boxSize.Width * boxSize.Height) + (boxSize.Width * boxSize.Length) +
        //				(boxSize.Height * boxSize.Length));
        //}
    }
}