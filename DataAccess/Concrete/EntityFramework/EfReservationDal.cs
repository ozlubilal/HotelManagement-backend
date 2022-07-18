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
    public class EfReservationDal : EfEntityRepositoryBase<Reservation, Context>, IReservationDal
    {
        public List<ReservationDetailDto> GetAllReservationDetail(Expression<Func<ReservationDetailDto, bool>> filter)
        {
            using (Context context = new Context())
            {
                var result = (from r in context.Reservations
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join room in context.Rooms
                             on r.RoomId equals room.Id                            
                             select new ReservationDetailDto
                             {
                                 ReservationId=r.Id,
                                 CustomerId = r.CustomerId,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,                                 
                                 PhoneNumber = c.PhoneNumber,
                                 StartDate = r.StartDate.Date,
                                 FinishDate = r.FinishDate.Date,
                                 Room=room,
                                 Price=r.Price,
                                                                  
                                          
                             });
                return filter == null ? result.ToList(): result.Where(filter).ToList();
            }
        }
    }
}
