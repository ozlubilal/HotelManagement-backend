using Business.Abstract;
using Business.Contans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;
      

        public RoomManager(IRoomDal roomDal)
        {
          
            _roomDal = roomDal;
          
        }

        public IResult Add(Room room)
        {
            IResult result = BusinessRules.Run(roomNumberIsExists(room.Number));

            if (result != null)
            {
                return result;
            }
            _roomDal.Add(room);
            return new SuccessResult(Messages.RoomAdded);
        }

        public IResult Delete(Room room)
        {
            _roomDal.Delete(room);
            return new SuccessResult(Messages.RoomDeleted);
        }

        public IDataResult<List<Room>> GetAll()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll());
        }

        public IDataResult<Room> GetById(int id)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(r=>r.Id==id));
        }

        public IDataResult<List<Room>> GetRoomByClassId(int id)
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(r=>r.RoomClassId==id));
        }

        public IDataResult<Room> GetRoomByNumber(string number)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(r=>r.Number==number));
        }

        public IDataResult<List<Room>> GetRoomByStatuId(int id)
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(r=>r.RoomStatuId==id));
        }
        public IDataResult<List<RoomDto>> GetRoomDto()
        {
            return new SuccessDataResult<List<RoomDto>>(_roomDal.GetRoomDto());
        }
        public IDataResult<List<RoomDto>> GetRoomDtoByRoomClassName(string roomClassName)
        {
            return new SuccessDataResult<List<RoomDto>>(_roomDal.GetRoomDto(r=>r.ClassName== roomClassName));
        }
        public IDataResult<List<RoomDto>> GetRoomDtoByRoomTypeName(string roomTypeName)
        {
            return new SuccessDataResult<List<RoomDto>>(_roomDal.GetRoomDto(r => r.TypeName == roomTypeName));
        }
        public IDataResult<RoomDto> GetRoomDtoByNumber(string number)
        {
            return new SuccessDataResult<RoomDto>(_roomDal.GetRoomDto(r => r.Number == number).FirstOrDefault());
        }
        public IDataResult<List<RoomDto>> GetRoomDtoByStatuName(string statuName)
        {
            return new SuccessDataResult<List<RoomDto>>(_roomDal.GetRoomDto(r => r.StatuName == statuName));
        }
        public IDataResult<Room> SelectRoom(int roomClassId, int roomTypeId)
        {            
            return new SuccessDataResult<Room>(_roomDal.Get(r=>r.RoomClassId == roomClassId && r.RoomTypeId==roomTypeId && r.RoomStatuId==1));
        }

        public IResult Update(Room room)
        {
            IResult result = BusinessRules.Run(roomNumberIsExists(room.Number));

            if (result != null)
            {
                return result;
            }
            _roomDal.Update(room);
            return new SuccessResult(Messages.RoomUpdated);
        }
        private IResult roomNumberIsExists(string roomNumber)
        {
            var result = _roomDal.GetAll(r => r.Number == roomNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.RoomNumberAlreadyExists);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
