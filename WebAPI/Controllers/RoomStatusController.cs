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
    public class RoomStatusController : ControllerBase
    {
        IRoomStatuService _roomStatuService;
        public RoomStatusController(IRoomStatuService roomStatuService)
        {
            _roomStatuService = roomStatuService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roomStatuService.GetAll();
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
            var result = _roomStatuService.GetById(id);
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
        public IActionResult GetById(string name)
        {
            var result = _roomStatuService.GetByName(name);
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
        public IActionResult Add(RoomStatu roomStatu)
        {
            var result = _roomStatuService.Add(roomStatu);
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
        public IActionResult Delete(RoomStatu roomStatu)
        {
            var result = _roomStatuService.Delete(roomStatu);
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
        public IActionResult Update(RoomStatu roomStatu)
        {
            var result = _roomStatuService.Update(roomStatu);
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
