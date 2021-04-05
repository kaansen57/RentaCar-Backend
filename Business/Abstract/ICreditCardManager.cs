using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardManager
    {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult CreditCardChecker(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAllList();
        IDataResult<List<CreditCard>> GetCreditCard(int id);
    }
}
