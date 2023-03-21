using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<ICarDal, EfCarDal>();
            builder.Services.AddSingleton<IBrandService, BrandManager>();
            builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
            builder.Services.AddSingleton<IColorService, ColorManager>();
            builder.Services.AddSingleton<IColorDal, EfColorDal>();
            builder.Services.AddSingleton<ICustomersService, CustomersManager>();
            builder.Services.AddSingleton<ICustomersDal, EfCustomersDal>();
            builder.Services.AddSingleton<IRentalsService, RentalsManager>();
            builder.Services.AddSingleton<IRentalsDal, EfRentalsDal>();
            builder.Services.AddSingleton<IUsersService, UsersManager>();
            builder.Services.AddSingleton<IUsersDal, EfUsersDal>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}