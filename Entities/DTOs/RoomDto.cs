using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RoomDto:IDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string ClassName { get; set; }
        public string StatuName { get; set; }
        public string Number { get; set; }

    }
}
