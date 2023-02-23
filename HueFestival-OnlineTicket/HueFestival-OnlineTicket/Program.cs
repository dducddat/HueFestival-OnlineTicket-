using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.Servies.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HueFestivalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HueFestival")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ILocationCategoryRepository, LocationCategoryRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ITickerLocationRepository, TicketLoactionRepository>();

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
