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
    public class RoomClassManager : IRoomClassService
    {
        IRoomClassDal _roomClassDal;

        public RoomClassManager(IRoomClassDal roomClassDal)
        {
            _roomClassDal = roomClassDal;
        }

        public IResult Add(RoomClass roomClass)
        {
            _roomClassDal.Add(roomClass);
            return new SuccessResult(Messages.RoomClassAdded);
        }

        public IResult Delete(RoomClass roomClass)
        {
            _roomClassDal.Delete(roomClass);
            return new SuccessResult(Messages.RoomClassDeleted);
        }

        public IDataResult<List<RoomClass>> GetAll()
        {
            return new SuccessDataResult<List<RoomClass>>(_roomClassDal.GetAll());
        }

        public IDataResult<RoomClass> GetById(int id)
        {
            return new SuccessDataResult<RoomClass>(_roomClassDal.Get(r=>r.Id==id));
        }

        public IDataResult<RoomClass> GetByName(string name)
        {
            return new SuccessDataResult<RoomClass>(_roomClassDal.Get(r=>r.Name==name));
        }

        public IResult Update(RoomClass roomClass)
        {
            _roomClassDal.Update(roomClass);
            return new SuccessResult(Messages.RoomClassUpdated);
        }
    }
}
