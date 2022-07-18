                                                                                                                                                                         using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RentalDetails:IEntity
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Boolean Statu { get; set; }
    }
}
