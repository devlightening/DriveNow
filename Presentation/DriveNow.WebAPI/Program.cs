using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers;

using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryWriteHandlers;
using DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactWriteHandlers;
using DriveNow.Application.Interfaces;
using DriveNow.Application.Interfaces.BlogContentInterfaces;
using DriveNow.Application.Interfaces.BlogInterfaces;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Application.Interfaces.CarPricingInterfaces;
using DriveNow.Application.Interfaces.CloudTagByBlogInterfaces;
using DriveNow.Application.Interfaces.CommentInterfaces;
using DriveNow.Application.Interfaces.TagCloudInterfaces;
using DriveNow.Application.Services;
using DriveNow.Persistance.Context;
using DriveNow.Persistance.Repositories;
using DriveNow.Persistance.Repositories.BlogContentRepositories;
using DriveNow.Persistance.Repositories.BlogRepositories;
using DriveNow.Persistance.Repositories.CarPricingRepositories;
using DriveNow.Persistance.Repositories.CarRepositories;
using DriveNow.Persistance.Repositories.CloudTagByBlogRepositories;
using DriveNow.Persistance.Repositories.CommentRepositories;
using DriveNow.Persistance.Repositories.TagCloudRepositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DriveNowContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // `IRepository<T>` için jenerik kayýt
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
        builder.Services.AddScoped<ICloudTagByBlogRepository, CloudTagByBlogRepository>();
        builder.Services.AddScoped<IBlogContentRepository, BlogContentRepository>();
        builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();

        //Repository Pattern  (Entites) Kayýt





        // Handler'larý  tek tek kaydederek devam ediyoruz.
        builder.Services.AddScoped<GetAboutQueryHandler>();
        builder.Services.AddScoped<GetAboutByIdQueryHandler>();
        builder.Services.AddScoped<CreateAboutCommandHandler>();
        builder.Services.AddScoped<RemoveAboutCommandHandler>();
        builder.Services.AddScoped<UpdateAboutCommandHandler>();

    
        builder.Services.AddScoped<GetBrandQueryHandler>();
        builder.Services.AddScoped<GetBrandByIdQueryHandler>();
        builder.Services.AddScoped<CreateBrandCommandHandler>();
        builder.Services.AddScoped<RemoveBrandCommandHandler>();
        builder.Services.AddScoped<UpdateBrandCommandHandler>();

        builder.Services.AddScoped<GetCarQueryHandler>();
        builder.Services.AddScoped<GetCarByIdQueryHandler>();
        builder.Services.AddScoped<CreateCarCommandHandler>();
        builder.Services.AddScoped<RemoveCarCommandHandler>();
        builder.Services.AddScoped<UpdateCarCommandHandler>();
        builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
        builder.Services.AddScoped<GetCarsByBrandQueryHandler>();
        builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
        builder.Services.AddScoped<GetCarsWithBrandQueryHandler>();
        builder.Services.AddScoped<GetPublishedCarsQueryHandler>();



        builder.Services.AddScoped<GetCategoryQueryHandler>();
        builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
        builder.Services.AddScoped<CreateCategoryCommandHandler>();
        builder.Services.AddScoped<RemoveCategoryCommandHandler>();
        builder.Services.AddScoped<UpdateCategoryCommandHandler>();


        builder.Services.AddScoped<GetContactQueryHandler>();
        builder.Services.AddScoped<GetContactByIdQueryHandler>();
        builder.Services.AddScoped<CreateContactCommandHandler>();
        builder.Services.AddScoped<RemoveContactCommandHandler>();
        builder.Services.AddScoped<UpdateContactCommandHandler>();

        // mediatR kayýt
        builder.Services.AddApplicationServices(builder.Configuration);

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });


        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowDriveNowWebUI",
                policy =>
                {
                    // Ön yüz uygulamanýzýn tam URL'sini belirtin
                    policy.WithOrigins("https://localhost:7182")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });
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
        app.UseCors("AllowDriveNowWebUI");

        app.MapControllers();

        app.Run();
    }
}