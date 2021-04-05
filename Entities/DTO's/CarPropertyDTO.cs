using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO_s
{
   public class CarPropertyDTO : IDto
    {
        public int Id { get; set; }
        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public int GearId { get; set; }
        public string GearName { get; set; }
        public int CarClassId { get; set; }
        public string CarClassName { get; set; }
    }
}
