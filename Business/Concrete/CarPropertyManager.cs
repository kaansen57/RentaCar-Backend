using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarPropertyManager : ICarPropertyManager
    {
        public IResult Add(CarProperty brand)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarProperty brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarProperty>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarProperty> GetCarProperty(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarProperty brand)
        {
            throw new NotImplementedException();
        }
    }
    
}
