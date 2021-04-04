using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int carId);
        IDataResult<List<Car>> GetByBrand(int brandId);
        IDataResult<List<Car>> GetByColor(int colorId);
        IDataResult<List<CarDTO>> GetUnitPriceFilter(int min, int max);
        IDataResult<List<CarDTO>> GetCarDetails();
        IDataResult<List<CarDTO>> GetCarDetailsId(int carId);
        IDataResult<List<CarDTO>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDTO>> GetCarDetailsByColor(int colorId);
        IResult AddTransactionalTest(Car car);
    }
}
