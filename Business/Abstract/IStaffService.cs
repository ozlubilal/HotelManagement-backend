using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IDataResult<List<Staff>> GetAll();
        IDataResult<Staff> GetById(int id);
        IDataResult<Staff> GetByTcNumber(string tcNumber);
        IDataResult<List<Staff>> GetByFullName(string firstName,string lastName);
        IDataResult<List<Staff>> GetByDepartmentId(int id);
        IDataResult<List<Staff>> GetByPositiontId(int id);
        IDataResult<List<StaffDto>> GetStaffDto();
        IDataResult<StaffDto> GetStaffDtoById(int id);

        IResult Add(Staff staff);
        IResult Update(Staff staff);
        IResult Delete(Staff staff);
    }
}
