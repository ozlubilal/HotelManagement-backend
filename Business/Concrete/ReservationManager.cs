using Business.Abstract;
using Business.Contans;
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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        IRoomService _roomService;
        ICustomerService _customerService;
        IRoomClassService _roomClassService;
        IRoomTypeService _roomTypeService;
        public ReservationManager(IReservationDal reservationDal,IRoomService roomService,ICustomerService customerService,
            IRoomClassService roomClassService,IRoomTypeService roomTypeService)
        {
            _reservationDal = reservationDal;
            _roomService = roomService;
            _customerService = customerService;
            _roomClassService =roomClassService;
            _roomTypeService = roomTypeService;

        }

        public IResult Add(ReservationDetailDto reservationDetailDto)
        {
            int customerId = reservationDetailDto.CustomerId;
            if (reservationDetailDto.CustomerId == 0)   //müşteri kayıtlı değilse kayıt ediliyor
            {
                var customer = new Customer
                {
                    FirstName = reservationDetailDto.FirstName,
                    LastName = reservationDetailDto.LastName,
                    PhoneNumber = reservationDetailDto.PhoneNumber,
                };
                _customerService.Add(customer);
                customerId = customer.Id;

            }

            var selectedRoom = _roomService.SelectRoom(reservationDetailDto.Room.RoomClassId, reservationDetailDto.Room.RoomTypeId).Data;
            selectedRoom.RoomStatuId = 1002;
            _roomService.Update(selectedRoom);
            decimal price = _roomClassService.GetById(reservationDetailDto.Room.RoomClassId).Data.Price*   //seçilen Odanın  ücreti hesaplanıyor
                _roomTypeService.GetById(reservationDetailDto.Room.RoomTypeId).Data.Price *(int)(reservationDetailDto.FinishDate-reservationDetailDto.StartDate).TotalDays;
            var reservation = new Reservation
            {
                CustomerId = customerId,
                RoomId = selectedRoom.Id,
                StartDate = reservationDetailDto.StartDate,
                FinishDate = reservationDetailDto.FinishDate,
                Price=price,
                
            };
            _reservationDal.Add(reservation);

            return new SuccessResult(Messages.ReservationAdded);
        }

        public IResult Delete(ReservationDetailDto reservationDetailDto)
        {
            Reservation reservation = _reservationDal.Get(r => r.Id == reservationDetailDto.ReservationId);
            _reservationDal.Delete(reservation);
            return new SuccessResult(Messages.ReservationDeleted);
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }
        public IDataResult<List<ReservationDetailDto>> GetAllReservationDetail()
        {

            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetAllReservationDetail());
        }
        public IDataResult<List<ReservationDetailDto>> GetReservationDetailByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetAllReservationDetail(r => r.CustomerId == customerId));
        }


        public IDataResult<List<Reservation>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.CustomerId == id));
        }

        public IDataResult<List<Reservation>> GetByDate(DateTime date1, DateTime date2)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.StartDate == date1 && r.FinishDate == date2));
        }

        public IDataResult<Reservation> GetByReservationId(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Reservation>> GetByRoomId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.RoomId == id));
        }

        public IDataResult<List<Reservation>> GetByStatu(bool statu)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.Statu == statu));
        }

        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(Messages.ReservationUpdated);
        }

        public IDataResult<List<ReservationDetailDto>> GetReservationDetailByFullName(string firstName, string lastName)
        {
            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetAllReservationDetail(r => r.FirstName == firstName && r.LastName == lastName));
        }

        public IDataResult<List<ReservationDetailDto>> GetReservationDetailByPhoneNumber(string phoneNumber)
        {
            return new SuccessDataResult<List<ReservationDetailDto>>(_reservationDal.GetAllReservationDetail(r => r.PhoneNumber == phoneNumber));
        }

       
    }
}
