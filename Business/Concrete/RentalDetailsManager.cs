using Business.Abstract;
using Business.Contans;
using Core.DataAccess;
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

namespace Business.Concrete
{
    public class RentalDetailsManager : IRentalDetailsService
    {
        IRentalDetailsDal _rentalDetailsDal;
        IRoomClassService _roomClassService;
        IRoomService _roomService;
        IRentalService _rentalService;
        IRoomTypeService _roomTypeService;
        ICustomerService _customerService;

        public RentalDetailsManager(IRentalDetailsDal rentalDetails, IRoomClassService roomClassService,
            IRoomService roomService,IRentalService rentalService,IRoomTypeService roomTypeService,ICustomerService customerService)
        {
            _rentalDetailsDal = rentalDetails;
            _roomClassService = roomClassService;
            _roomService = roomService;
            _rentalService = rentalService;
            _roomTypeService = roomTypeService;
            _customerService = customerService;
         
        }

        public IResult Add(RentalDetailsDetailDto rentalDetailsDetailDto)
        {
            int customerId = rentalDetailsDetailDto.CustomerId;
            //müşteri kayıtlı değilse kayıt ediliyor
            if (rentalDetailsDetailDto.CustomerId == 0)  
            {
                var customer = new Customer
                {
                    FirstName = rentalDetailsDetailDto.FirstName,
                    LastName = rentalDetailsDetailDto.LastName,
                    PhoneNumber = rentalDetailsDetailDto.PhoneNumber,
                };
                _customerService.Add(customer);
                customerId = customer.Id;

            }
            //girilen roomtype ve roomclass a göre oda seçiliyor
            var selectedRoom = _roomService.SelectRoom(rentalDetailsDetailDto.Room.RoomClassId, rentalDetailsDetailDto.Room.RoomTypeId).Data;
            selectedRoom.RoomStatuId =2;  //oda durumunu dolu yapıyor
            _roomService.Update(selectedRoom);
            decimal price = _roomClassService.GetById(rentalDetailsDetailDto.Room.RoomClassId).Data.Price *   //seçilen Odanın  ücreti hesaplanıyor
                _roomTypeService.GetById(rentalDetailsDetailDto.Room.RoomTypeId).Data.Price * (int)(rentalDetailsDetailDto.FinishDate - rentalDetailsDetailDto.StartDate).TotalDays;
           
            var rental = new Rental { 
            CustomerId= customerId,
            TransactionDate=DateTime.Now,
            };
            _rentalService.Add(rental);
            var rentalDetails = new RentalDetails
            {
                RentalId=rental.RentalId,
                RoomId = selectedRoom.Id,
                StartDate = rentalDetailsDetailDto.StartDate,
                FinishDate = rentalDetailsDetailDto.FinishDate,
                Price = price,
                
            };
            _rentalDetailsDal.Add(rentalDetails);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(RentalDetailsDetailDto rentalDetailsDetailDto)
        {
            RentalDetails rentalDetails = _rentalDetailsDal.Get(r => r.Id == rentalDetailsDetailDto.rentalDetailId);
            _rentalDetailsDal.Delete(rentalDetails);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<RentalDetails>> GetAll()
        {
            return new SuccessDataResult<List<RentalDetails>>(_rentalDetailsDal.GetAll());
        }
        public IDataResult<List<RentalDetailsDetailDto>> GetRentalDetailsDetail()
        {
            return new SuccessDataResult<List<RentalDetailsDetailDto>>(_rentalDetailsDal.GetRentalDetailDto());
        }
        public IDataResult<List<RentalDetailsDetailDto>> GetRentalDetailsDetailByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailsDetailDto>>(_rentalDetailsDal.GetRentalDetailDto(r=>r.CustomerId==customerId));
        }
        public IDataResult<List<RentalDetailsDetailDto>> GetReservationDetailByFullName(string firstName, string lastName)
        {
            return new SuccessDataResult<List<RentalDetailsDetailDto>>(_rentalDetailsDal.GetRentalDetailDto(r => r.FirstName == firstName && r.LastName == lastName));
        }
        public IDataResult<List<RentalDetailsDetailDto>> GetReservationDetailByPhoneNumber(string phoneNumber)
        {
            return new SuccessDataResult<List<RentalDetailsDetailDto>>(_rentalDetailsDal.GetRentalDetailDto(r => r.PhoneNumber == phoneNumber));
        }
        public IDataResult<RentalDetails> GetRentalDetailsByRentalDetailId(int rentalDetailId)
        {
            return new SuccessDataResult<RentalDetails>(_rentalDetailsDal.Get(r => r.Id == rentalDetailId));
        }


        public IDataResult<List<RentalDetails>> GetByDate(DateTime date1, DateTime date2)
        {
            return new SuccessDataResult<List<RentalDetails>>(_rentalDetailsDal.GetAll(r => r.StartDate == date1 && r.FinishDate == date2));
        }

        public IDataResult<RentalDetails> GetByRentalId(int id)
        {
            return new SuccessDataResult<RentalDetails>(_rentalDetailsDal.Get(r => r.RentalId == id));
        }

        public IDataResult<RentalDetails> GetByRoomId(int id)
        {
            return new SuccessDataResult<RentalDetails>(_rentalDetailsDal.Get(r => r.RoomId == id));
        }

        public IResult ReservationToRent(ReservationDetailDto reservationDetailDto)
        {
            Rental rental = new Rental { CustomerId = reservationDetailDto.CustomerId, TransactionDate = DateTime.Now };
            _rentalService.Add(rental);
            RentalDetails rentalDetails = new RentalDetails {RentalId=rental.RentalId,RoomId= reservationDetailDto.Room.Id,Price= reservationDetailDto.Price,
                                                            StartDate= reservationDetailDto.StartDate,FinishDate= reservationDetailDto.FinishDate };
            _rentalDetailsDal.Add(rentalDetails);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult Update(RentalDetails rentalDetails)
        {
            _rentalDetailsDal.Update(rentalDetails);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
