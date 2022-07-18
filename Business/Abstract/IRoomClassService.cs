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
    public interface IRoomClassService
    {
        IDataResult<List<RoomClass>> GetAll();
        IDataResult<RoomClass> GetById(int id);
        IDataResult<RoomClass> GetByName(string name);

        IResult Add(RoomClass roomClass);
        IResult Update(RoomClass roomClass);
        IResult Delete(RoomClass roomClass);


    }
}
