using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFuelManager
    {
        IResult Add(Fuel brand);
        IResult Delete(Fuel brand);
        IResult Update(Fuel brand);
        IDataResult<List<Fuel>> GetAllList();
        IDataResult<Fuel> GetFuel(int id);
    }
}
