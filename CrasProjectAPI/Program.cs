using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

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
            builder.Services.AddDbContext<AppDbContext>();
            // Register application services
            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<IBlogDal, BlogDal>();

            builder.Services.AddScoped<ICommentService, CommentManager>();
            builder.Services.AddScoped<ICommentDal, CommentDal>();

            builder.Services.AddScoped<ICarService, CarManager>();
            builder.Services.AddScoped<ICarDal, CarDal>();

            builder.Services.AddScoped<IValidator<Blog>, BlogValidation>();
            builder.Services.AddScoped<IValidator<Comment>, CommentValidation>();
    

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
