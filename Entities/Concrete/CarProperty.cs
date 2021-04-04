using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarProperty : IEntity
    {
        public int Id { get; set; }
        public int GearId { get; set; }
        public int FuelId { get; set; }
        public int CarClassId { get; set; }
    }
}
