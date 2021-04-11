using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserJwtManager : IUserJwtManager
    {
        IUserJwtDal _userDal;

        public UserJwtManager(IUserJwtDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(UserJWT user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(UserJWT user)
        {
           _userDal.Add(user);
        }

        public UserJWT GetByMail(string email)
        {   
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<UserJWT>> GetAll()
        {
            return new SuccessDataResult<List<UserJWT>>(_userDal.GetAll(),"Kullanıcılar Listelendi");
        }
        public IDataResult<List<UserJWT>> GetUser(string email)
        {
            return new SuccessDataResult<List<UserJWT>>(_userDal.GetAll(x=>x.Email == email), "Kullanıcılar Listelendi");
        }

        public IDataResult<List<UserJWT>> GetById(int id)
        {
            return new SuccessDataResult<List<UserJWT>>(_userDal.GetAll(x => x.Id == id), "Kullanıcılar Listelendi");
        }

        public IResult Update(UserJWT user)
        {
            var result = _userDal.GetAll(x => x.Email == user.Email);
            if (result.Any())
            {
                return new ErrorResult();
            }
             _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(UserJWT user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
    }
}
