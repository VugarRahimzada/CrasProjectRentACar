using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;
using BusinessLayer.Validation.FluentValidation;
using CoreLayer.Tools;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using EntityLayer.Concrete.TableModels.Membership;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrasProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<AppDbContext>()
                         .AddIdentity<ApplicationUser, ApplicationRole>()
                         .AddEntityFrameworkStores<AppDbContext>()
                         .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = JwtTokenDefaults.ValidIssuer,
                    ValidAudience = JwtTokenDefaults.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });

            // Register services and validators
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

            builder.Services.AddScoped<IBookingService, BookingManager>();
            builder.Services.AddScoped<IBookingDal, BookingDal>();

            builder.Services.AddScoped<IValidator<Blog>, BlogValidation>();
            builder.Services.AddScoped<IValidator<Comment>, CommentValidation>();
            builder.Services.AddScoped<IValidator<Car>, CarValidation>();
            builder.Services.AddScoped<IValidator<Body>, BodyValidation>();
            builder.Services.AddScoped<IValidator<Brand>, BrandValidation>();
            builder.Services.AddScoped<IValidator<Door>, DoorValidation>();
            builder.Services.AddScoped<IValidator<Fuel>, FuelValidation>();
            builder.Services.AddScoped<IValidator<Transmission>, TransmissionValidation>();
            builder.Services.AddScoped<IValidator<Booking>, BookingValidation>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
