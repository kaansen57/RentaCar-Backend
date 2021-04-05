using Core.Abstract;

namespace Entities.Concrete
{
    public class CarClass : IEntity
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }

}
