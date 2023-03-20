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
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetCar(int Id);
        IDataResult<List<RentalsDetailDto>> GetRentalsDetail();
        IResult Add(Rentals rentals);
        IResult Update(Rentals rentals);
        IResult Delete(Rentals rentals);
    }
}
