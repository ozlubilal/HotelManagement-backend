using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StaffDepartmentManager : IStaffDepartmentService
    {
        IStaffDepartmentDal _staffDepartmentDal;
        public StaffDepartmentManager(IStaffDepartmentDal staffDepartmentDal)
        {
            _staffDepartmentDal = staffDepartmentDal;
        }

        public IResult Add(StaffDepartment staffDepartment)
        {
            _staffDepartmentDal.Add(staffDepartment);
            return new SuccessResult(Messages.StaffDepartmentAdded);
        }

        public IResult Delete(StaffDepartment staffDepartment)
        {
            _staffDepartmentDal.Delete(staffDepartment);
            return new SuccessResult(Messages.StaffDepartmentDeleted);
        }

        public IDataResult<List<StaffDepartment>> GetAll()
        {
            return new SuccessDataResult<List<StaffDepartment>>(_staffDepartmentDal.GetAll());
        }

        public IDataResult<StaffDepartment> GetById(int id)
        {
            return new SuccessDataResult<StaffDepartment>(_staffDepartmentDal.Get(s=>s.Id==id));
        }

        public IDataResult<StaffDepartment> GetByName(string name)
        {
            return new SuccessDataResult<StaffDepartment>(_staffDepartmentDal.Get(s => s.Name == name));
        }

        public IResult Update(StaffDepartment staffDepartment)
        {
            _staffDepartmentDal.Update(staffDepartment);
            return new SuccessResult(Messages.StaffDepartmentUpdated);
        }
    }
}
