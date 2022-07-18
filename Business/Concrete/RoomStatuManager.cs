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
    public class RoomStatuManager:IRoomStatuService
    {
        IRoomStatuDal _roomStatuDal;

        public RoomStatuManager(IRoomStatuDal roomStatuDal)
        {
            _roomStatuDal = roomStatuDal;
        }

        public IResult Add(RoomStatu roomStatu)
        {
            _roomStatuDal.Add(roomStatu);
            return new SuccessResult(Messages.RoomStatuAdded);
        }

        public IResult Delete(RoomStatu roomStatu)
        {
            _roomStatuDal.Delete(roomStatu);
            return new SuccessResult(Messages.RoomStatuDeleted);
        }

        public IDataResult<List<RoomStatu>> GetAll()
        {
            return new SuccessDataResult<List<RoomStatu>>(_roomStatuDal.GetAll());
        }

        public IDataResult<RoomStatu> GetById(int id)
        {
            return new SuccessDataResult<RoomStatu>(_roomStatuDal.Get(r => r.Id == id));
        }

        public IDataResult<RoomStatu> GetByName(string name)
        {
            return new SuccessDataResult<RoomStatu>(_roomStatuDal.Get(r => r.Statu == name));
        }

        public IResult Update(RoomStatu roomStatu)
        {
            _roomStatuDal.Update(roomStatu);
            return new SuccessResult(Messages.RoomStatuUpdated);
        }

    }
}
