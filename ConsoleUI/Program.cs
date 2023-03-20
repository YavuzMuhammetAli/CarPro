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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CustomersTest();            
            //UsersTest();
            //UsersAddedTest();
            //RentalsAddedTest();
            //RentalsTest();
        }

        private static void RentalsAddedTest()
        {
            RentalsManager rentals = new RentalsManager(new EfRentalsDal());

            Rentals rent = new Rentals();
            rent.Id = 10;
            rent.CarId = 3;
            rent.CustomerId = 3;
            rent.RentDate = DateTime.Now;
            rent.ReturnDate = new DateTime(2023, 03, 25);
            rentals.Add(rent);
        }

        private static void UsersAddedTest()
        {
            UsersManager users = new UsersManager(new EfUsersDal());

            Users user = new Users();
            user.Id = 10;
            user.FirstName = "Muhammet Ali";
            user.LastName = "YAVUZ";
            user.Email = "ornek@gmail.com";
            user.Password = "123456";
            users.Add(user);
        }

        private static void UsersTest()
        {
            UsersManager users = new UsersManager(new EfUsersDal());

            var result = users.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Email);
                }
            }
        }

        private static void CustomersTest()
        {
            CustomersManager customers = new CustomersManager(new EfCustomersDal());

            var result = customers.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.UserId + " " + item.CompanyName + " " + item.Id);
                }
            }
        }

        private static void ColorTest()
        {
            ColorManager color = new ColorManager(new EfColorDal());

            var result = color.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.isim);
                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brand = new BrandManager(new EfBrandDal());

            var result = brand.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.isim);
                }
            }
        }

        private static void RentalsTest()
        {
            RentalsManager rent = new RentalsManager(new EfRentalsDal());
            var result = rent.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    //Console.WriteLine(item.CarName + " " + item.CustomerName + " " + item.Id);
                    Console.WriteLine("CarId: " + item.CarId + " ReturnDate: " + item.ReturnDate.ToString() + " CustomerId: " + item.CustomerId);
                }
            }
        }

        private static void CarTest()
        {
            CarManager car = new CarManager(new EfCarDal());

            var result = car.GetCarDetails();
            if (result.Success == true)
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