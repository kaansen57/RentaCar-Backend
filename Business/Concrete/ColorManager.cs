using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorManager
    {
        private IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        public IResult Add(Color brand)
        {
            _color.Add(brand);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult Delete(Color brand)
        {
            _color.Delete(brand);
            return new SuccessResult(Messages.DeleteSuccess);
        }
        public IResult Update(Color brand)
        {
            _color.Update(brand);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IDataResult<List<Color>> GetAllList()
        {
            var result = _color.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetColor(int colorId)
        {
            var result = _color.Get(c => c.ColorId == colorId);
            return new SuccessDataResult<Color>(result);
        }


    }
}
