using Business.Abstract;
using Business.Contans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        public IDataResult<User> GetUserByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
        public IDataResult<UserDetailDto> GetUserDetailsByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetails().Where(u=>u.Email==email).FirstOrDefault());
        }
    

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
        {
            User user = _userDal.Get(u => u.Id == userId);
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(UserForUpdateDto userUpdateDto)
        {
            var userForUpdate = GetUserByUserId(userUpdateDto.Id).Data;
            userForUpdate.FirstName = userUpdateDto.FirstName;
            userForUpdate.LastName = userUpdateDto.LastName;
            userForUpdate.Email = userUpdateDto.Email;
            _userDal.Update(userForUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

       
    }
}
