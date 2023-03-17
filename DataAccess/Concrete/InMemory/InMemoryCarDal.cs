using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=1,ModelYear=2023,DailyPrice=100,Aciklama="Audi"},
                new Car {Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=200,Aciklama="Mercedes"},
                new Car {Id=3,BrandId=2,ColorId=2,ModelYear=2021,DailyPrice=300,Aciklama="Seat"},
                new Car {Id=4,BrandId=3,ColorId=4,ModelYear=2017,DailyPrice=400,Aciklama="Bmw"},
                new Car {Id=5,BrandId=3,ColorId=4,ModelYear=2015,DailyPrice=500,Aciklama="Skoda"}
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = cars.SingleOrDefault(p => p.Id == car.Id);
            cars.Remove(carsToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(p => p.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = cars.SingleOrDefault(p => p.Id == car.Id);
            carsToUpdate.Id = car.Id;
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Aciklama = car.Aciklama;
        }
    }
}
