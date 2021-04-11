using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimManager
    {
        private IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult();
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            var result = _operationClaimDal.GetAll();
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IDataResult<List<OperationClaim>> GetOperationClaim(int operationClaimId)
        {
            var result = _operationClaimDal.GetAll(x => x.Id == operationClaimId);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult();
        }
    }
}
