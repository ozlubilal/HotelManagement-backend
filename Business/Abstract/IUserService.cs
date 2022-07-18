using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(UserForUpdateDto userUpdateDto);
        User GetByMail(string email);
        IDataResult<User> GetUserByMail(string email);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        IDataResult<List<User>> GetAll();
        public IDataResult<User> GetUserByUserId(int userId);
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId);
    }
}
