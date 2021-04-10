using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomerManager
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAllList();
        IDataResult<List<Customer>> GetCustomer(int customerId);
        IDataResult<List<Customer>> GetCustomerByUserId(int userId);

    }
}
