using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetByFullName(string firstname, string lastName);
        IDataResult<Customer> GetByPhoneNumber(string phoneNumber);
        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<Customer> GetByFullNameAndPhoneNumber(string firstname, string lastName, string phoneNumber);

        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
