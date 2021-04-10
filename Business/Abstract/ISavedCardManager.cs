using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISavedCardManager
    {
        IResult Add(SavedCard creditCard);
        IResult Delete(SavedCard creditCard);
        IResult Update(SavedCard creditCard);
        IResult CreditCardChecker(SavedCard creditCard);
        IDataResult<List<SavedCard>> GetAllList();
        IDataResult<List<SavedCard>> GetCreditCard(int id);
        IDataResult<List<SavedCard>> GetUserCreditCard(int userId);
    }
}
