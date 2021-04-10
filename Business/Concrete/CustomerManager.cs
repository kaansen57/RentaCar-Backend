using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDelete);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetCustomer(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Id == customerId));
        }

        public IDataResult<List<Customer>> GetCustomerByUserId(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == userId));
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAllList() { 
            var customer =  _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customer);
        }
    }
}
