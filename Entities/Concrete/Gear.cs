using Core.Abstract;

namespace Entities.Concrete
{
    public class Gear : IEntity
    {
        public int Id { get; set; }
        public string GearType { get; set; }
    }

}
