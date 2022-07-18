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
    public class StaffPositionManager : IStaffPositionService
    {
        IStaffPositionDal _staffPositionDal;
        public StaffPositionManager(IStaffPositionDal staffPositionDal)
        {
            _staffPositionDal = staffPositionDal;
        }
        public IResult Add(StaffPosition staffPosition)
        {
            _staffPositionDal.Add(staffPosition);
            return new SuccessResult(Messages.StaffPositionAdded);
        }

        public IResult Delete(StaffPosition staffPosition)
        {
            _staffPositionDal.Delete(staffPosition);
            return new SuccessResult(Messages.StaffPositionDeleted);
        }

        public IDataResult<List<StaffPosition>> GetAll()
        {
          
            return new SuccessDataResult<List<StaffPosition>>(_staffPositionDal.GetAll());
        }

        public IDataResult<StaffPosition> GetById(int id)
        {
           
            return new SuccessDataResult<StaffPosition>(_staffPositionDal.Get(s => s.Id == id));
        }

        public IDataResult<StaffPosition> GetByName(string name)
        {
           
            return new SuccessDataResult<StaffPosition>(_staffPositionDal.Get(s => s.Name == name));
        }

        public IResult Update(StaffPosition staffPosition)
        {
            _staffPositionDal.Update(staffPosition);
            return new SuccessResult(Messages.StaffPositionUpdated);
        }
    }
}
