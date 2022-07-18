using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfRentalDetailsDal : EfEntityRepositoryBase<RentalDetails, Context>, IRentalDetailsDal
    {
        public List<RentalDetailsDetailDto> GetRentalDetailDto(Expression<Func<RentalDetailsDetailDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from r in context.Rentals
                             join rd in context.RentalDetails
                             on r.RentalId equals rd.RentalId
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join room in context.Rooms
                             on rd.RoomId equals room.Id
                             select new RentalDetailsDetailDto
                             {
                                 rentalDetailId=rd.Id,
                                 RentalId = r.RentalId,
                                 CustomerId =c.Id,
                                 FirstName=c.FirstName,
                                 LastName=c.LastName,
                                 PhoneNumber=c.PhoneNumber,
                                 Room=room,   
                                 Price = rd.Price,
                                 StartDate = rd.StartDate,
                                 FinishDate = rd.FinishDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
