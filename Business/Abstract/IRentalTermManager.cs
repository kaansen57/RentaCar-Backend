using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalTermManager
    {
        IResult Add(RentalTerm rentalTerm);
        IResult Delete(RentalTerm rentalTerm);
        IResult Update(RentalTerm rentalTerm);
        IDataResult<List<RentalTerm>> GetAll();
        IDataResult<List<RentalTerm>> GetRentalTerm(int carId);
    }
}
