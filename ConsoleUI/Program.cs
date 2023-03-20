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

            var result = car.GetCarDetails();
            if(result.Success==true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}