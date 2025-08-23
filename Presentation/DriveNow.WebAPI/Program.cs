using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers;
using DriveNow.Application.Interfaces;
using DriveNow.Persistance.Context;
using DriveNow.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DriveNowContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// `IRepository<T>` için jenerik kaydý ekliyoruz. Bu, tüm repository'ler için geçerli olacak.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Handler'larý MediatR ile deðil, tek tek kaydederek devam ediyoruz.
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

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