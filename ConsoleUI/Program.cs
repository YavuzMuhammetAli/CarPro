using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new EfCarDal());
            EfCarDal ef = new EfCarDal();
            Car c = new Car();
            c.Id = 11;
            c.BrandId = 11;
            c.ColorId = 11;
            c.ModelYear = 2020;
            c.DailyPrice = 25000;
            c.Aciklama = "Alfa";
            ef.Add(c);
            foreach (var item in car.GetAll())
            {
                Console.WriteLine(item.Aciklama);
            }
        }
    }
}