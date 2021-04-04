using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarPropertyDal : EfEntityRepositoryBase<CarProperty, CarContext>, ICarPropertyDal
    {

    }
}
