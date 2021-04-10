using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarManager
    {
        private ICarDal _carDal;
        private IBrandManager _brandManager;
      

        //bir entity manager kendi yapısındaki dal hariç başka yapıyı enjekte edemez
        //dependecy enjection
        public CarManager(ICarDal carDal , IBrandManager brandManager)
        {
            _carDal = carDal;
            _brandManager = brandManager;
         
        }
        //[SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Add(Car car)
        {
         IResult result = BusinessRule.Run(
                CheckBrandCountCorrect(car.BrandId)
                ,CheckDuplicateCarName(car.CarName)
                 //,CheckBrandLimit()
                );
        
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccess);
        }

        //[SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarList);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetById(int carId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == carId),Messages.CarList);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.CarList);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.CarList);
        }
        [CacheAspect]
        public IDataResult<List<CarDTO>> GetUnitPriceFilter(int min, int max)
        {
            return new SuccessDataResult<List<CarDTO>>(_carDal.GetCarDetails(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }
        [CacheAspect]
        public IDataResult<List<CarDTO>> GetCarDetails()
        {
            var cardto = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDTO>>(cardto); 
        }
        [CacheAspect]
        public IDataResult<List<CarDTO>> GetCarDetailsId(int carId)
        {
            var cardto = _carDal.GetCarDetails(x=>x.Id == carId);
            return new SuccessDataResult<List<CarDTO>>(cardto);
        }
        [CacheAspect]
        public IDataResult<List<CarDTO>> GetCarDetailsByBrand(int brandId)
        {
            var cardto = _carDal.GetCarDetails(x => x.BrandId == brandId);
            return new SuccessDataResult<List<CarDTO>>(cardto);
        }
        [CacheAspect]
        public IDataResult<List<CarDTO>> GetCarDetailsByColor(int colorId)
        {
            var cardto = _carDal.GetCarDetails(x => x.ColorId == colorId);
            return new SuccessDataResult<List<CarDTO>>(cardto);
        }

        private IResult CheckBrandCountCorrect(int brandId)
        {
            int limit = 5;
            var result = _carDal.GetAll(x => x.BrandId == brandId).Count;
            if (result > limit)
            {
                return new ErrorResult( "Aynı Markaya "+limit+"'den fazla araç eklenemez!");
            }
            return new SuccessResult();
        }

        private IResult CheckDuplicateCarName(string carName)
        {
            //var result = _carDal.GetAll(x => x.CarName == carName).Any(); 
            // eğer böyle belirtilen kriterde data varsa true döner
            var result = _carDal.GetAll(x => x.CarName == carName).Count;
            if (result>0)
            {
                return new ErrorResult(Messages.CarSameData);
            }
            return new SuccessResult();
        }

        private IResult CheckBrandLimit()
        {
            //var result = _brandManager.GetAll().Data.Count;
            //if (result > 10)
            //{
            //    return new ErrorResult(Messages.CarBrandLimit);
            //}
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 400)
            {
                throw new Exception("");
            }
            Add(car);
            return new SuccessResult();
        }

        
    }
}
