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
    public class RoomsController : ControllerBase
    {
        IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _roomService.GetAll();
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
            var result = _roomService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroombyclassid")]
        public IActionResult GetRoomByClassId(int id)
        {
            var result = _roomService.GetRoomByClassId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroombystatuid")]
        public IActionResult GetRoomByStatuId(int id)
        {
            var result = _roomService.GetRoomByStatuId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroombynumber")]
        public IActionResult GetRoomByNumber(string number)
        {
            var result = _roomService.GetRoomByNumber(number);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getroomdto")]
        public IActionResult GetRoomDto()
        {
            var result = _roomService.GetRoomDto();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroomdtobyclassname")]
        public IActionResult GetRoomDtoByClassName(string className)
        {
            var result = _roomService.GetRoomDtoByRoomClassName(className);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroomdtobytypename")]
        public IActionResult GetRoomDtoByTypeName(string typeName)
        {
            var result = _roomService.GetRoomDtoByRoomTypeName(typeName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroomdtobynumber")]
        public IActionResult GetRoomDtoByNumber(string number)
        {
            var result = _roomService.GetRoomDtoByNumber(number);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getroomdtobystatuname")]
        public IActionResult GetRoomDtoByStatuName(string statu)
        {
            var result = _roomService.GetRoomDtoByStatuName(statu);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("selectroom")]
        public IActionResult SelectRoom(int roomClassId,int roomTypeId)
        {
            var result = _roomService.SelectRoom(roomClassId,roomTypeId);
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
        public IActionResult Add(Room room)
        {
            var result = _roomService.Add(room);
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
        public IActionResult Delete(Room room)
        {
            var result = _roomService.Delete(room);
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
        public IActionResult Update(Room room)
        {
            var result = _roomService.Update(room);
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
