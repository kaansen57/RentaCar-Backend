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
        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int CarPropertyId { get; set; }
        public string ModelYear  { get; set; }
        public int FindexScore { get; set; }

    }
}
