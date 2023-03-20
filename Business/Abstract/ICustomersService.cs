using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customers>> GetAll();
        IDataResult<List<CustomersDetailDto>> GetCustomersByUsersId(int Id);
        IResult Add(Customers customers);
        IResult Update(Customers customers);
        IResult Delete(Customers customers);
    }
}
