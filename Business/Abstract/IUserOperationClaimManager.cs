using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserOperationClaimManager
    {
        IResult Add(UserOperationClaim operationClaim);
        IResult Delete(UserOperationClaim operationClaim);
        IResult Update(UserOperationClaim operationClaim);
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<List<UserOperationClaim>> GetUserOperationClaim(int userOperationClaimId);
    }
}
