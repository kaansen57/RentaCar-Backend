using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarPropertyDal : EfEntityRepositoryBase<CarProperty, CarContext>, ICarPropertyDal
    {
        public List<CarPropertyDTO> GetCarPropertyDetails(Expression<Func<CarPropertyDTO, bool>> filter = null)
        {
            using (CarContext carContext = new CarContext())
            {
                var result = from cp in carContext.CarProperties
                             join fu in carContext.Fuel
                             on cp.FuelId equals fu.Id
                             join ge in carContext.Gear
                             on cp.GearId equals ge.Id
                             join carc in carContext.CarClass
                             on cp.CarClassId equals carc.Id
                             select new CarPropertyDTO
                             {
                                 Id = cp.Id,
                                 FuelId = fu.Id,
                                 FuelName = fu.FuelType,
                                 GearId = ge.Id,
                                 GearName = ge.GearType,
                                 CarClassId = carc.Id,
                                 CarClassName = carc.ClassName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
