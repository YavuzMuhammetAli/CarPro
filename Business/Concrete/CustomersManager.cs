using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
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
    public class CustomersManager : ICustomersService
    {
        ICustomersDal _customers;
        public CustomersManager(ICustomersDal customers)
        {
            _customers = customers;
        }

        public IResult Add(Customers customers)
        {
            _customers.Add(customers);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customers customers)
        {
            _customers.Delete(customers);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customers.GetAll());
        }

        public IDataResult<List<CustomersDetailDto>> GetCustomersByUsersId(int Id)
        {
            return new SuccessDataResult<List<CustomersDetailDto>>(_customers.GetCustomerDetail());
        }

        public IResult Update(Customers customers)
        {
            _customers.Update(customers);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
