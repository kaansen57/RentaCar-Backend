using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarClassManager
    {
        IResult Add(CarClass brand);
        IResult Delete(CarClass brand);
        IResult Update(CarClass brand);
        IDataResult<List<CarClass>> GetAllList();
        IDataResult<CarClass> GetCarClass(int id);
    }
}
