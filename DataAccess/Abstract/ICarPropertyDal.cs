using Entities.Concrete;
using Core.Abstract;
using System.Collections.Generic;
using Entities.DTO_s;
using System.Linq.Expressions;
using System;

namespace DataAccess.Abstract
{
    public interface ICarPropertyDal : IEntityRepository<CarProperty>
    {
         List<CarPropertyDTO> GetCarPropertyDetails(Expression<Func<CarPropertyDTO, bool>> filter = null);
       
    }

}
