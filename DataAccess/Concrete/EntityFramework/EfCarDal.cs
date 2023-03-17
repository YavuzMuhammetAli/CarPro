using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ArabaContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ArabaContext context= new ArabaContext())
            {
                var result = from x in context.Car
                             join y in context.Brand
                             on x.BrandId equals y.Id
                             join z in context.Color
                             on x.ColorId equals z.Id
                             select new CarDetailDto { Id = x.Id, CarName=x.Aciklama, BrandName = y.isim, ColorName = z.isim };
                return result.ToList();
            }
        }
    }
}
