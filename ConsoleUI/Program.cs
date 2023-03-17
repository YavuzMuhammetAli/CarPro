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
            CarTest();

        }

        private static void CarTest()
        {
            CarManager car = new CarManager(new EfCarDal());
            foreach (var item in car.GetCarDetails())
            {
                Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName);
            }
        }
    }
}