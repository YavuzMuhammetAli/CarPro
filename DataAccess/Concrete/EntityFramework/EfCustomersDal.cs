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
    public class EfCustomersDal : EfEntityRepositoryBase<Customers, ArabaContext>, ICustomersDal
    {
        public List<CustomersDetailDto> GetCustomerDetail()
        {
            using (ArabaContext context = new ArabaContext())
            {
                var result = from x in context.Customers
                             join y in context.Users
                             on x.UserId equals y.Id
                             select new CustomersDetailDto { Id = x.Id, CustomerName = x.CompanyName, UserName = y.FirstName };
                return result.ToList();
            }
        }
    }
}
