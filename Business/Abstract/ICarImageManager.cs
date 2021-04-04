using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageManager
    {
        IResult Add(CarImage entity,IFormFile formFile);
        IResult Delete(CarImage entity);
        IResult Update(CarImage entity, IFormFile formFile);
        IDataResult<List<CarImage>> GetAllList();
        IDataResult<List<CarImage>> GetAllSingleList();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> Get(int id);
    }
}
