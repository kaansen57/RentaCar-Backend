using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class SavedCardManager : ISavedCardManager
    {
        private ISavedCardDal _savedCardDal;
        public SavedCardManager(ISavedCardDal savedCardDal)
        {
            _savedCardDal = savedCardDal;
        }
        public IResult Add(SavedCard creditCard)
        {
            _savedCardDal.Add(creditCard);
            return new SuccessResult(Messages.CardSaved);
        }

        public IResult CreditCardChecker(SavedCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(SavedCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<SavedCard>> GetAllList()
        {
            var result = _savedCardDal.GetAll();
            return new SuccessDataResult<List<SavedCard>>(result);
        }

        public IDataResult<List<SavedCard>> GetCreditCard(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<SavedCard>> GetUserCreditCard(int userId)
        {
            var result = _savedCardDal.GetAll(x=>x.UserId == userId);
            return new SuccessDataResult<List<SavedCard>>(result);
        }

        public IResult Update(SavedCard creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
