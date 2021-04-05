using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGearManager
    {
        IResult Add(Gear gear);
        IResult Delete(Gear gear);
        IResult Update(Gear gear);
        IDataResult<List<Gear>> GetAllList();
        IDataResult<Gear> GetGear(int id);
    }
}
