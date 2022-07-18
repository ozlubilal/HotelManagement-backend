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
    public interface IReservationService
    {
        IDataResult<List<Reservation>> GetAll();
        IDataResult<List<ReservationDetailDto>> GetAllReservationDetail();
        IDataResult<List<ReservationDetailDto>> GetReservationDetailByCustomerId(int customerId);
        IDataResult<List<ReservationDetailDto>> GetReservationDetailByFullName(string firstName,string lastName);
        IDataResult<List<ReservationDetailDto>> GetReservationDetailByPhoneNumber(string phoneNumber);
        IDataResult<Reservation> GetByReservationId(int id);
        IDataResult<List<Reservation>> GetByCustomerId(int id);
        IDataResult<List<Reservation>> GetByRoomId(int id);
        IDataResult<List<Reservation>> GetByDate(DateTime date1, DateTime date2);
        IDataResult<List<Reservation>> GetByStatu(Boolean statu);

        IResult Add(ReservationDetailDto reservationDetailDto);
        IResult Update(Reservation reservation);
        IResult Delete(ReservationDetailDto reservationDetailDto);


    }
}
