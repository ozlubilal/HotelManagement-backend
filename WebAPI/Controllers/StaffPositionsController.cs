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
    public class StaffPositionsController : ControllerBase
    {
        IStaffPositionService _staffPositionService;
        public StaffPositionsController(IStaffPositionService staffPositionService)
        {
            _staffPositionService = staffPositionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _staffPositionService.GetAll();
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
            var result = _staffPositionService.GetById(id);
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
            var result = _staffPositionService.GetByName(name);
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
        public IActionResult Add(StaffPosition staffPosition)
        {
            var result = _staffPositionService.Add(staffPosition);
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
        public IActionResult Delete(StaffPosition staffPosition)
        {
            var result = _staffPositionService.Delete(staffPosition);
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
        public IActionResult Update(StaffPosition staffPosition)
        {
            var result = _staffPositionService.Update(staffPosition);
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
