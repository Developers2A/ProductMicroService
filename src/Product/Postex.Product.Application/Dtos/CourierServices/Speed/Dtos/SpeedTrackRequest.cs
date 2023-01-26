namespace Postex.Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedTrackRequest
    {
        public long Barcode { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (Barcode <= 0)
            {
                return new(false, "Barcode must be graeter than zero.");
            }
            return (status, message);
        }
    }
}
