using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGearManager
    {
        IResult Add(Gear brand);
        IResult Delete(Gear brand);
        IResult Update(Gear brand);
        IDataResult<List<Gear>> GetAllList();
        IDataResult<Gear> GetGear(int id);
    }
}
