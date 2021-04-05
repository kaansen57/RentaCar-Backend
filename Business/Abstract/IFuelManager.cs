using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFuelManager
    {
        IResult Add(Fuel fuel);
        IResult Delete(Fuel fuel);
        IResult Update(Fuel fuel);
        IDataResult<List<Fuel>> GetAllList();
        IDataResult<Fuel> GetFuel(int id);
    }
}
