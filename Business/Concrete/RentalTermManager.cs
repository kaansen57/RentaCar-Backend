using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalTermManager : IRentalTermManager
    {
        private IRentalTermDal _rentalTermDal; 
        public RentalTermManager(IRentalTermDal rentalTermDal)
        {
            _rentalTermDal = rentalTermDal;
        }
        public IResult Add(RentalTerm rentalTerm)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(RentalTerm rentalTerm)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalTerm>> GetAll()
        {

            var result = _rentalTermDal.GetAll();
            return new SuccessDataResult<List<RentalTerm>>(result);
        }

        public IDataResult<List<RentalTerm>> GetRentalTerm(int carId)
        {
            var result = _rentalTermDal.GetAll(x=>x.CarId == carId);
            return new SuccessDataResult<List<RentalTerm>>(result);
        }

        public IResult Update(RentalTerm rentalTerm)
        {
            throw new NotImplementedException();
        }
    }
}
