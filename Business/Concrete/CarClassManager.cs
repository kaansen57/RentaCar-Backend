using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarClassManager : ICarClassManager
    {
        public IResult Add(CarClass brand)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarClass brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarClass>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarClass> GetCarClass(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarClass brand)
        {
            throw new NotImplementedException();
        }
    }
}
