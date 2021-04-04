using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAllList();
        IDataResult<List<Rental>> GetRental(int rentalId);
        IResult GetRentalDate(int carId ,DateTime rentDate, DateTime returnDate);
        IDataResult<List<RentalDTO>> GetRentalDetails();
    }
}
