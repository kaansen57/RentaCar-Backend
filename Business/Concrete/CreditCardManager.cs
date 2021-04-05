using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardManager
    {
        private ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult CreditCardChecker(CreditCard creditCard)
        {
            var result = _creditCardDal.GetAll(
                x => 
                x.CardNumber == creditCard.CardNumber 
                && x.ExpirationMonth == creditCard.ExpirationMonth
                && x.ExpirationYear == creditCard.ExpirationYear
                && x.Cvv == creditCard.Cvv
                && x.CustomerName == creditCard.CustomerName
                && x.CustomerSurname == creditCard.CustomerSurname
                );

            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAllList()
        {
            var result = _creditCardDal.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IDataResult<List<CreditCard>> GetCreditCard(int id)
        {
            var result = _creditCardDal.GetAll(x=>x.Id == id);
            return new SuccessDataResult<List<CreditCard>>(result);
        }

       
    }
}
