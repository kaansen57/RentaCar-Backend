using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimManager
    {
        private IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim operationClaim)
        {
            _userOperationClaimDal.Add(operationClaim);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim operationClaim)
        {
            _userOperationClaimDal.Delete(operationClaim);
            return new SuccessResult();
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            var result = _userOperationClaimDal.GetAll();
            return new SuccessDataResult<List<UserOperationClaim>>(result);
        }

        public IDataResult<List<UserOperationClaim>> GetUserOperationClaim(int userOperationClaimId)
        {
            var result = _userOperationClaimDal.GetAll(x=>x.Id == userOperationClaimId);
            return new SuccessDataResult<List<UserOperationClaim>>(result);
        }

        public IResult Update(UserOperationClaim operationClaim)
        {
            _userOperationClaimDal.Update(operationClaim);
            return new SuccessResult();
        }
    }
}
