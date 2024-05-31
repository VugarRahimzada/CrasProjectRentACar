using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using EntityLayer.Concrete.TableModels.Membership;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CrasProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        //    builder.Services.AddControllers()
        //.AddJsonOptions(options =>
        //{
        //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        //    options.JsonSerializerOptions.MaxDepth = 64;
        //});


            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
          
            
            
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();


            builder.Services.AddDbContext<AppDbContext>()
             .AddIdentity<ApplicationUser, ApplicationRole>()
             .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });




            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<IBlogDal, BlogDal>();

            builder.Services.AddScoped<ICommentService, CommentManager>();
            builder.Services.AddScoped<ICommentDal, CommentDal>();

            builder.Services.AddScoped<ICarService, CarManager>();
            builder.Services.AddScoped<ICarDal, CarDal>();

            builder.Services.AddScoped<IBrandService, BrandManager>();
            builder.Services.AddScoped<IBrandDal, BrandDal>();

            builder.Services.AddScoped<IBodyService, BodyManager>();
            builder.Services.AddScoped<IBodyDal, BodyDal>();

            builder.Services.AddScoped<IDoorService, DoorManager>();
            builder.Services.AddScoped<IDoorDal, DoorDal>();

            builder.Services.AddScoped<IFuelService, FuelManager>();
            builder.Services.AddScoped<IFuelDal, FuelDal>();

            builder.Services.AddScoped<ITransmissionService, TransmissionManager>();
            builder.Services.AddScoped<ITransmissionDal, TransmissionDal>();

            builder.Services.AddScoped<IValidator<Blog>, BlogValidation>();
            builder.Services.AddScoped<IValidator<Comment>, CommentValidation>();
            builder.Services.AddScoped<IValidator<Car>, CarValidation>();
            builder.Services.AddScoped<IValidator<Body>, BodyValidation>();
            builder.Services.AddScoped<IValidator<Brand>, BrandValidation>();
            builder.Services.AddScoped<IValidator<Door>, DoorValidation>();
            builder.Services.AddScoped<IValidator<Fuel>, FuelValidation>();
            builder.Services.AddScoped<IValidator<Transmission>, TransmissionValidation>();
        


            // Add Swagger for API documentation
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
