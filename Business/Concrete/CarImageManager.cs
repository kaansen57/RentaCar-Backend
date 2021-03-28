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
using System.Linq;

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
            IResult result = BusinessRule.Run(CheckImageLimit(carImage));
            if (result == null)
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
            return new ErrorResult(Messages.ImageUpdateError);
        }
        public IDataResult<CarImage> Get(int carId)
        {
            try
            {
                var result = _carImageDal.Get(x => x.CarId == carId);
                
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
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRule.Run(CheckImageNull(carId));
            if (result == null)
            {
                return new SuccessDataResult<List<CarImage>>(CheckImageNull(carId).Data);
            }

            return new ErrorDataResult<List<CarImage>>(result.Message);
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

        private IDataResult<List<CarImage>> CheckImageNull(int carId)
        {
            try
            {
                var defaultImage = Environment.CurrentDirectory + @"\wwwroot\Uploads\default.png";
                var result = _carImageDal.GetAll(x => x.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = defaultImage, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }

                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CarImage>>(ex.Message);
            }
        }

    }
}
