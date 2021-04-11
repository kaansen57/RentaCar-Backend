using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOperationClaimManager
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<List<OperationClaim>> GetOperationClaim(int operationClaimId);
    }
}
