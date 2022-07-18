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
    public interface IStaffPositionService
    {
        IDataResult<List<StaffPosition>> GetAll();
        IDataResult<StaffPosition> GetById(int id);
        IDataResult<StaffPosition> GetByName(string name);

        IResult Add(StaffPosition staffPosition);
        IResult Update(StaffPosition staffPosition);
        IResult Delete(StaffPosition staffPosition);
    }
}
