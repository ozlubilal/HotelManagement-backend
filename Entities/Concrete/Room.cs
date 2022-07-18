using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Room:IEntity
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomClassId { get; set; }
        public int RoomStatuId { get; set; }
        public string Number { get; set; }


    }
}
