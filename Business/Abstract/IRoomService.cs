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
    public interface IRoomService
    {
        IDataResult<List<Room>> GetAll();
        IDataResult<Room> GetById(int id);
        IDataResult<List<Room>> GetRoomByClassId(int id);
        IDataResult<List<Room>> GetRoomByStatuId(int id);
        IDataResult<Room> GetRoomByNumber(string number);
        IDataResult<Room> SelectRoom(int roomClassId, int roomTypeId);

        IDataResult<List<RoomDto>> GetRoomDto();
        IDataResult<List<RoomDto>> GetRoomDtoByRoomClassName(string roomClassName);
        IDataResult<List<RoomDto>> GetRoomDtoByRoomTypeName(string roomTypeName);
        IDataResult<RoomDto> GetRoomDtoByNumber(string number);
        IDataResult<List<RoomDto>> GetRoomDtoByStatuName(string statuName);

        IResult Add(Room room);
        IResult Update(Room room);
        IResult Delete(Room room);


    }
}
