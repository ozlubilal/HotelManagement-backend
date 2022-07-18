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
    public interface IRentalDetailsService
    {
        IDataResult<List<RentalDetails>> GetAll();
        IDataResult<RentalDetails> GetByRentalId(int id);
        IDataResult<RentalDetails> GetByRoomId(int id);
        IDataResult<List<RentalDetails>> GetByDate(DateTime date1,DateTime date2);
        IDataResult<List<RentalDetailsDetailDto>> GetRentalDetailsDetail();
        IDataResult<List<RentalDetailsDetailDto>> GetRentalDetailsDetailByCustomerId(int customerId);
        IDataResult<List<RentalDetailsDetailDto>> GetReservationDetailByFullName(string firstName, string lastName);
        IDataResult<List<RentalDetailsDetailDto>> GetReservationDetailByPhoneNumber(string phoneNumber);
        IDataResult<RentalDetails> GetRentalDetailsByRentalDetailId(int rentalDetailId);





        IResult Add(RentalDetailsDetailDto rentalDetailsDetailDto);
        IResult Update(RentalDetails rentalDetails);
        IResult Delete(RentalDetailsDetailDto rentalDetailsDetailDto);
        IResult ReservationToRent(ReservationDetailDto reservationDetailDto);
    }
}
