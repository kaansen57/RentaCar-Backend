using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarContext>, ICarImageDal
    {
        class ImageCarIdComparer : IEqualityComparer<CarImage>
        {
            public bool Equals(CarImage x, CarImage y)
            {
                if (Equals(x.CarId, y.CarId))
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(CarImage obj)
            {
                return obj.CarId.GetHashCode();
            }
        }

        public List<CarImage> GetCarImage(Expression<Func<CarImage, bool>> filter = null)
        {
            using (CarContext carContext = new CarContext())
            {
                var query = from c in carContext.CarImages
                                     group c by c.CarId into newGroup
                                     orderby newGroup.Key
                                     select newGroup;

                var result = from c in carContext.CarImages
                              select new CarImage
                              {
                                  Id = c.Id,
                                  CarId = c.CarId,
                                  ImagePath = c.ImagePath,
                                  Date = c.Date
                              };

                return result.Distinct().ToList();
            }
        }
    }
}
