using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO_s
{
    public class RentalDTO : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string UserFullName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
    }
}
