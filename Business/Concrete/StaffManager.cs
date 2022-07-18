using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StaffManager:IStaffService
    {
        IStaffDal _staffDal;
        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult(Messages.StaffAdded);
        }

        public IResult Delete(Staff staff)
        {
            _staffDal.Delete(staff);
                return new SuccessResult(Messages.StaffDeleted);
           
        }

        public IDataResult<List<Staff>> GetAll()
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll());
        }

        public IDataResult<List<Staff>> GetByDepartmentId(int id)
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(s=>s.DepartmentId==id));
        }

        public IDataResult<List<Staff>> GetByFullName(string firstName, string lastName)
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(s=>s.FirstName==firstName&&s.LastName==lastName));
        }

        public IDataResult<Staff> GetById(int id)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(s=>s.Id==id));
        }

        public IDataResult<List<Staff>> GetByPositiontId(int id)
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(s=>s.PositionId==id));
        }

        public IDataResult<Staff> GetByTcNumber(string tcNumber)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(s=>s.TcNumber==tcNumber));
        }

        public IDataResult<List<StaffDto>> GetStaffDto()
        {
            return new SuccessDataResult<List<StaffDto>>(_staffDal.GetStaffDto());
        }
        public IDataResult<StaffDto> GetStaffDtoById(int id)
        {
            return new SuccessDataResult<StaffDto>(_staffDal.GetStaffDto(s=>s.Id==id).FirstOrDefault());
        }

        public IResult Update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult(Messages.StaffUpdated);
        }
    }
}
