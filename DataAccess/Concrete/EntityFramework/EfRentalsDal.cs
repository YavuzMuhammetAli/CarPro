using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, ArabaContext>, IRentalsDal
    {
        public List<RentalsDetailDto> GetRentalsDetail()
        {
            using (ArabaContext context = new ArabaContext())
            {
                var result = from x in context.Rentals
                             join y in context.Car
                             on x.CarId equals y.Id
                             join z in context.Customers
                             on x.CustomerId equals z.Id
                             select new RentalsDetailDto { Id = x.Id, CarName = y.Aciklama, CustomerName = z.CompanyName };
                return result.ToList();
            }
        }
    }
}
