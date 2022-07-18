using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomTypeManager:IRoomTypeService
    {
        IRoomTypeDal _roomTypeDal;

        public RoomTypeManager(IRoomTypeDal roomTypeDal)
        {
            _roomTypeDal = roomTypeDal;
        }

        public IResult Add(RoomType roomType)
        {
            _roomTypeDal.Add(roomType);
            return new SuccessResult(Messages.RoomTypeAdded);
        }

        public IResult Delete(RoomType roomType)
        {
            _roomTypeDal.Delete(roomType);
            return new SuccessResult(Messages.RoomTypeDeleted);
        }

        public IDataResult<List<RoomType>> GetAll()
        {
            return new SuccessDataResult<List<RoomType>>(_roomTypeDal.GetAll());
        }

        public IDataResult<RoomType> GetById(int id)
        {
            return new SuccessDataResult<RoomType>(_roomTypeDal.Get(r => r.Id == id));
        }

        public IDataResult<RoomType> GetByName(string name)
        {
            return new SuccessDataResult<RoomType>(_roomTypeDal.Get(r => r.Name == name));
        }

        public IResult Update(RoomType roomType)
        {
            _roomTypeDal.Update(roomType);
            return new SuccessResult(Messages.RoomTypeUpdated);
        }

    }
}
