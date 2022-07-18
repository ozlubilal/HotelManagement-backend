using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal : EfEntityRepositoryBase<Room, Context>, IRoomDal
    {
        public List<RoomDto> GetRoomDto(Expression<Func<RoomDto, bool>> filter = null)
        {
            using (Context context=new Context())
            {
                var result = from r in context.Rooms
                             join rc in context.RoomClasses
                             on r.RoomClassId equals rc.Id
                             join rt in context.RoomTypes
                             on r.RoomTypeId equals rt.Id
                             join rs in context.RoomStatus
                             on r.RoomStatuId equals rs.Id
                             select new RoomDto
                             {
                                 Id=r.Id,
                                 TypeName=rt.Name,
                                 ClassName=rc.Name,
                                 StatuName=rs.Statu,
                                 Number=r.Number
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

      
    }
}
