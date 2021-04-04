using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorManager
    {
        IResult Add(Color brand);
        IResult Delete(Color brand);
        IResult Update(Color brand);
        IDataResult<List<Color>> GetAllList();
        IDataResult<Color> GetColor(int colorId);
    }
}
