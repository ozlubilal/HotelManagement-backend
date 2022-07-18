using Business.Abstract;
using Entities.Concrete;
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
    public class StaffsController : ControllerBase
    {
        IStaffService _staffService;
        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;       
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _staffService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _staffService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbytcnumber")]
        public IActionResult GetByTcNumber(string tcNumber)
        {
            var result = _staffService.GetByTcNumber(tcNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyfullname")]
        public IActionResult GetByFullName(string firstName, string lastName)
        {
            var result = _staffService.GetByFullName(firstName, lastName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbydepartmentid")]
        public IActionResult GetByDpartmentID(int id)
        {
            var result = _staffService.GetByDepartmentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbypositionid")]
        public IActionResult GetByPositionId(int id)
        {
            var result = _staffService.GetByPositiontId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getstaffdto")]
        public IActionResult GetStaffDto()
        {
            var result = _staffService.GetStaffDto();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getstaffdtobyid")]
        public IActionResult GetStaffDtoById(int id)
        {
            var result = _staffService.GetStaffDtoById(id);
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
        public IActionResult Add(Staff staff)
        {
            var result = _staffService.Add(staff);
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
        public IActionResult Delete(Staff staff)
        {
            var result = _staffService.Delete(staff);
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
        public IActionResult Update(Staff staff)
        {
            var result = _staffService.Update(staff  );
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
