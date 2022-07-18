using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStaffDal : EfEntityRepositoryBase<Staff, Context>, IStaffDal
    {
        public List<StaffDto> GetStaffDto(Expression<Func<StaffDto, bool>> filter = null)
        {
            using (Context context=new Context())
            {
                var result = from s in context.Staffs
                             join sd in context.StaffDepartments
                             on s.DepartmentId equals sd.Id
                             join sp in context.StaffPositions
                             on s.PositionId equals sp.Id
                             select new StaffDto 
                             {
                                 Id=s.Id,
                                 TcNumber = s.TcNumber,
                                 FirstName =s.FirstName,
                                 LastName=s.LastName,
                                 DepartmentName=sd.Name,
                                 PositionName=sp.Name
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
