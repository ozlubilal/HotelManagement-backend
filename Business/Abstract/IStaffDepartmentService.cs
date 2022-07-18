using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffDepartmentService
    {
        IDataResult<List<StaffDepartment>> GetAll();
        IDataResult<StaffDepartment> GetById(int id);
        IDataResult<StaffDepartment> GetByName(string name);

        IResult Add(StaffDepartment staffDepartment);
        IResult Update(StaffDepartment staffDepartment);
        IResult Delete(StaffDepartment staffDepartment);
    }
}
