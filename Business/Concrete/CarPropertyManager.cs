using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarPropertyManager : ICarPropertyManager
    {
        private ICarPropertyDal _carPropDal;
        public CarPropertyManager(ICarPropertyDal carProperty)
        {
            _carPropDal = carProperty;
        }
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

        public IDataResult<List<CarPropertyDTO>> GetAllPropertyDetail()
        {
            var result = _carPropDal.GetCarPropertyDetails();
            return new SuccessDataResult<List<CarPropertyDTO>>(result);
        }

        public IDataResult<CarProperty> GetCarProperty(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarPropertyDTO>> GetPropertyDetail(int propId)
        {
            var result = _carPropDal.GetCarPropertyDetails(x=>x.Id == propId);
            return new SuccessDataResult<List<CarPropertyDTO>>(result);
        }

        public IResult Update(CarProperty brand)
        {
            throw new NotImplementedException();
        }
    }
    
}
