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
    public class StaffDepartmentsController : ControllerBase
    {
        IStaffDepartmentService _staffDepartmentService;
        public StaffDepartmentsController(IStaffDepartmentService staffDepartmentService)
        {
            _staffDepartmentService = staffDepartmentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _staffDepartmentService.GetAll();
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
            var result = _staffDepartmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _staffDepartmentService.GetByName(name);
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
        public IActionResult Add(StaffDepartment staffDepartment)
        {
            var result = _staffDepartmentService.Add(staffDepartment);
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
        public IActionResult Delete(StaffDepartment staffDepartment)
        {
            var result = _staffDepartmentService.Delete(staffDepartment);
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
        public IActionResult Update(StaffDepartment staffDepartment)
        {
            var result = _staffDepartmentService.Update(staffDepartment);
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
