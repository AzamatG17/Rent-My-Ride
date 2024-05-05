using RendMyRide.Domain.Common;

namespace RendMyRide.Domain.Models
{
    public class Driver : EntityBase
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string DriverLicenseNumber { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
