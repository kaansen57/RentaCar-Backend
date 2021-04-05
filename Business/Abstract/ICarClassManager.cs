using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarClassManager
    {
        IResult Add(CarClass carClass);
        IResult Delete(CarClass carClass);
        IResult Update(CarClass carClass);
        IDataResult<List<CarClass>> GetAllList();
        IDataResult<CarClass> GetCarClass(int id);
    }
}
