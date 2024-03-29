﻿using Business.Abstract;
using Business.Contans;
using Core.Utilities.Business;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(customerIsExist(customer));
            if(result!=null)
            {
                return result;
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByFullName(string firstname, string lastName)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.FirstName==firstname && c.LastName==lastName));
        }
        public IDataResult<Customer> GetByFullNameAndPhoneNumber(string firstname, string lastName,string phoneNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.FirstName == firstname && c.LastName == lastName && c.PhoneNumber==phoneNumber));
        }
        public IDataResult<Customer> GetByPhoneNumber(string phoneNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.PhoneNumber == phoneNumber));
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id==id));
        }
        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == userId));
        }

        

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        private IResult customerIsExist(Customer customer)
        {
            var result = _customerDal.GetAll(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName &&
            c.PhoneNumber == customer.PhoneNumber).Any();
            if(result)
            {
                return new ErrorResult(Messages.customerIsAlready);
            }
            return new SuccessResult();
        }
    }
}
