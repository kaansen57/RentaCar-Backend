using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FuelManager : IFuelManager
    {
        public IResult Add(Fuel fuel)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Fuel fuel)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Fuel>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Fuel> GetFuel(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Fuel fuel)
        {
            throw new NotImplementedException();
        }
    }
}
