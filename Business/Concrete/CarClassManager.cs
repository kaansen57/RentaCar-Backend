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
        public IResult Add(CarClass carClass)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarClass carClass)
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

        public IResult Update(CarClass carClass)
        {
            throw new NotImplementedException();
        }
    }
}
