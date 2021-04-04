using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarPropertyManager
    {
        IResult Add(CarProperty brand);
        IResult Delete(CarProperty brand);
        IResult Update(CarProperty brand);
        IDataResult<List<CarProperty>> GetAllList();
        IDataResult<CarProperty> GetCarProperty(int id);
    }
}
