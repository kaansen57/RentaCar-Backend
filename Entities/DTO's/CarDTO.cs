using Core;
using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class CarDTO : IDto
    {
        [Key]
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int CarPropertyId { get; set; }
        public int GearId { get; set; }
        public string Gear { get; set; }
        public int FuelId { get; set; }
        public string Fuel { get; set; }
        public int CarClassId { get; set; }
        public string CarClass  { get; set; }


    }
}
