using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDTO> GetRentalDetails()
        {
            using (CarContext carContext = new CarContext())
            {
                var details = from r in carContext.Rentals
                              join cu in carContext.Customers
                              on r.CustomerId equals cu.Id
                              join u in carContext.UsersJWT
                              on cu.UserId equals u.Id
                              join ca in carContext.Car
                              on r.CarId equals ca.Id
                              join b in carContext.Brand
                              on ca.BrandId equals b.BrandId
                              select new RentalDTO { CarName = ca.CarName, BrandName = b.BrandName, UserFullName = u.FirstName + " " + u.LastName, CompanyName = cu.CompanyName , RentDate = r.RentDate };
                              return details.ToList();
            }
        }
    }
}
