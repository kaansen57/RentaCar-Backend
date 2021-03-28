using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using System.IO;
using Core.Utilities.Helpers;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageManager
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRule.Run(CheckImageLimit(carImage));
            if (result == null)
            {
                carImage.Date = DateTime.Now;
                carImage.ImagePath = FileHelper.Add(formFile);
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ImageUploadSuccess);
            }
            return new ErrorResult(Messages.ImageUploadError);
        }

        public IResult Delete(CarImage carImage)
        {
            try
            {
                var deleteImage = _carImageDal.Get(x => x.Id == carImage.Id);
                if (deleteImage == null)
                {
                    return new ErrorResult(Messages.ImageDeleteError);
                }
                var deleteResult = FileHelper.Delete(deleteImage.ImagePath);

                if (deleteResult.Success)
                {
                    _carImageDal.Delete(carImage);
                    return new SuccessResult(Messages.ImageDeleteSuccess);
                }
                return new ErrorResult(Messages.ImageDeleteError);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ImageDeleteError);
            }
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            try
            {
                var deleteImage = _carImageDal.Get(x => x.Id == carImage.Id);
                if (deleteImage == null)
                {
                    return new ErrorResult(Messages.ImageUpdateError);
                }
                carImage.ImagePath = FileHelper.Update(deleteImage.ImagePath, formFile);
                carImage.Date = DateTime.Now;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.ImageUpdateSuccess);
            }
            catch (Exception)
            {
                return new SuccessResult(Messages.ImageUpdateError);
            }
        
        }
        public IDataResult<CarImage> Get(int id)
        {
            try
            {
                var result = _carImageDal.Get(x => x.Id == id);
                return new SuccessDataResult<CarImage>(result);
            }
            catch (Exception)
            {
                return new ErrorDataResult<CarImage>();
            }
        }
        public IDataResult<List<CarImage>> GetAllList()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);

        }
        public IDataResult<List<CarImage>> GetAllCarId(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(result);

        }

        private IResult CheckImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageUploadError);
            }
            return new SuccessResult(Messages.ImageUploadSuccess);
        }


    }
}
