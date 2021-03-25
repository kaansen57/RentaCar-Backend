using Core.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDTO> GetRentalDetails();
    }
}
