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
    public class RentalDetailsController : ControllerBase
    {
        IRentalDetailsService _rentalDetailsService;
        public RentalDetailsController(IRentalDetailsService rentalDetailService)
        {
            _rentalDetailsService = rentalDetailService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalDetailsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyrentalid")]
        public IActionResult GetByRentalId(int id)
        {
            var result = _rentalDetailsService.GetByRentalId(id);
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
            var result = _rentalDetailsService.GetByRoomId(id);
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
        public IActionResult GetByDate(DateTime startDate,DateTime finishDate)
        {
            var result = _rentalDetailsService.GetByDate(startDate,finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getrentaldetailsdetail")]
        public IActionResult GetRentalDetailsDetail()
        {
            var result = _rentalDetailsService.GetRentalDetailsDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getrentaldetailsdetailbycustomerid")]
        public IActionResult GetRentalDetailsDetailByCustomerId(int customerId)
        {
            var result = _rentalDetailsService.GetRentalDetailsDetailByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getrentaldetailsdetailbyfullname")]
        public IActionResult GetRentalDetailsDetailByFullName(string firstName, string lastName)
        {
            var result = _rentalDetailsService.GetReservationDetailByFullName(firstName,lastName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getrentaldetailsdetailbyphonenumber")]
        public IActionResult GetRentalDetailsDetailByPhoneNumber(string phoneNumber)
        {
            var result = _rentalDetailsService.GetReservationDetailByPhoneNumber(phoneNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getrentaldetailsbyrentaldetailid")]
        public IActionResult GetRentalDetailsByRentalDetailId(int rentalDetailId)
        {
            var result = _rentalDetailsService.GetRentalDetailsByRentalDetailId(rentalDetailId);
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
        public IActionResult Add(RentalDetailsDetailDto rentalDetailsDetailDto)
        {
            var result = _rentalDetailsService.Add(rentalDetailsDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("reservationtorent")]
        public IActionResult ReservationtoRent(ReservationDetailDto reservationDetailDto)
        {
            var result = _rentalDetailsService.ReservationToRent(reservationDetailDto);
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
        public IActionResult Delete(RentalDetailsDetailDto rentalDetailsDetailDto)
        {
            var result = _rentalDetailsService.Delete(rentalDetailsDetailDto);
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
        public IActionResult Update(RentalDetails rentalDetails)
        {
            var result = _rentalDetailsService.Update(rentalDetails);
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
