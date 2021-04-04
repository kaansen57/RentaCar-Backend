using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GearManager : IGearManager
    {
        public IResult Add(Gear brand)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Gear brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Gear>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Gear> GetGear(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Gear brand)
        {
            throw new NotImplementedException();
        }
    }
}
