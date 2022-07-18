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
    public interface IRoomStatuService
    {       
        IDataResult<List<RoomStatu>> GetAll();
        IDataResult<RoomStatu> GetById(int id);
        IDataResult<RoomStatu> GetByName(string name);

        IResult Add(RoomStatu roomStatu);
        IResult Update(RoomStatu roomStatu);
        IResult Delete(RoomStatu roomStatu);
    }
}
