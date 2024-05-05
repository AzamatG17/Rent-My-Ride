using RendMyRide.Domain.Common;

namespace RendMyRide.Domain.Models
{
    public class Car : EntityBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool AvailableForRent { get; set; }
        public decimal PricePerHour { get; set; }
        public DateTime RentStartTime { get; set; }
        public DateTime RentEndTime { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
