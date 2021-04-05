using Core.Abstract;

namespace Entities.Concrete
{
    public class RentalTerm : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Deposit { get; set; }
        public string DailyKmLimit { get; set; }
        public string DriverAge { get; set; }
        public string DriverLicenceLimit { get; set; }
        public string Fuse { get; set; }

    }
}
