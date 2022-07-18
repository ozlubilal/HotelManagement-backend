using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _reservationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getallreservationdetail")]
        public IActionResult GetAllReservationDetail()
        {
            var result = _reservationService.GetAllReservationDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getreservationdetailbycustomerid")]        
        public IActionResult GetReservationDetailByCustomerId(int customerId)
        {
            var result = _reservationService.GetReservationDetailByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getreservationdetailbyfullname")]
        public IActionResult GetReservationDetailByFullName(string firstName,string lastName)
        {
            var result = _reservationService.GetReservationDetailByFullName(firstName,lastName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getreservationdetailbyphoneNumber")]
        public IActionResult GetReservationDetailByPhoneNumber(string phoneNumber)
        {
            var result = _reservationService.GetReservationDetailByPhoneNumber(phoneNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyreservationid")]
        public IActionResult GetByReservationId(int id)
        {
            var result = _reservationService.GetByReservationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _reservationService.GetByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyroomid")]
        public IActionResult GetByRoomId(int id)
        {
            var result = _reservationService.GetByRoomId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbydate")]
        public IActionResult GetByReservationId(DateTime date1,DateTime date2)
        {
            var result = _reservationService.GetByDate(date1,date2);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbystatu")]
        public IActionResult GetByStatuId(Boolean statu)
        {
            var result = _reservationService.GetByStatu(statu);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(ReservationDetailDto reservationDetailDto)
        {
            var result = _reservationService.Add(reservationDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("delete")]
        public IActionResult Delete(ReservationDetailDto reservationDetailDto)
        {
            var result = _reservationService.Delete(reservationDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(Reservation reservation)
        {
            var result = _reservationService.Update(reservation);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
