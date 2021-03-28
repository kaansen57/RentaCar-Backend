﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDTO> GetCarDetails(Expression<Func<CarDTO, bool>> filter = null)
        {
            using (CarContext carContext = new CarContext())
            {
                var details = from c in carContext.Car
                              join b in carContext.Brand
                              on c.BrandId equals b.BrandId
                              join co in carContext.Color
                              on c.ColorId equals co.ColorId
                              select new CarDTO
                              {
                                  CarId = c.Id,
                                  CarName = c.CarName,
                                  BrandId = b.BrandId,
                                  BrandName = b.BrandName,
                                  ColorId = co.ColorId,
                                  ColorName = co.ColorName,
                                  DailyPrice = c.DailyPrice,
                              };
               return filter == null ? details.ToList() : details.Where(filter).ToList();
                //return  details.ToList() ;
            }
            
        }

    }

}
