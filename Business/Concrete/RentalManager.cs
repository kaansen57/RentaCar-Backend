using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result.ReturnDate != null && result.ReturnDate < rental.RentDate)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdd);
            }
            return new ErrorResult(Messages.RentalAddError);
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteSuccess);
        }

        public IResult Update(Rental rental)
        {
            rental.RentDate = DateTime.Now;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdateSuccess);
        }
        public IDataResult<List<Rental>> GetAllList()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.CarList);
        }

        public IDataResult<List<Rental>> GetRental(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == rentalId));
        }
        public IResult GetRentalDate(int carId , DateTime rentDate , DateTime returnDate)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate >= rentDate && r.RentDate <= returnDate);
            if (result.Any())
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
        public IDataResult<List<RentalDTO>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDTO>>(result);
        }
    }
}
