using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentals;
        public RentalsManager(IRentalsDal rentals)
        {
            _rentals = rentals;
        }

        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalsNotAdded);
            }
            _rentals.Add(rentals);
            return new SuccessResult(Messages.RentalsAdded);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentals.Delete(rentals);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentals.GetAll());
        }

        public IDataResult<Rentals> GetCar(int Id)
        {
            return new SuccessDataResult<Rentals>(_rentals.Get(p => p.CarId == Id));
        }

        public IDataResult<List<RentalsDetailDto>> GetRentalsDetail()
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentals.GetRentalsDetail());
        }

        public IResult Update(Rentals rentals)
        {
            _rentals.Update(rentals);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
