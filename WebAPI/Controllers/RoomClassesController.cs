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
    public class RoomClassesController : ControllerBase
    {
        IRoomClassService _roomClassService;
        public RoomClassesController(IRoomClassService roomClassService)
        {
            _roomClassService = roomClassService;

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roomClassService.GetAll();
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
            var result = _roomClassService.GetById(id);
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
            var result = _roomClassService.GetByName(name);
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
        public IActionResult Add(RoomClass roomClass)
        {
            var result = _roomClassService.Add(roomClass);
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
        public IActionResult Delete(RoomClass roomClass)
        {
            var result = _roomClassService.Delete(roomClass);
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
        public IActionResult Update(RoomClass roomClass)
        {
            var result = _roomClassService.Update(roomClass);
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
