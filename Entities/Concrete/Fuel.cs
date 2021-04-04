using Core.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Fuel : IEntity
    {
        public int Id { get; set; }
        public string FuelName { get; set; }
    }

}
