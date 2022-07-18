using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomTypeService
    {
        IDataResult<List<RoomType>> GetAll();
        IDataResult<RoomType> GetById(int id);
        IDataResult<RoomType> GetByName(string name);

        IResult Add(RoomType roomType);
        IResult Update(RoomType roomType);
        IResult Delete(RoomType roomType);
    }
}
