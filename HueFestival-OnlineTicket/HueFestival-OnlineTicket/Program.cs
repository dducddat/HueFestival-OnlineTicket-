using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.Service;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HueFestivalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HueFestival")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILocationCategoryService, LocationCategoryService>();
builder.Services.AddScoped<ITicketLocationService, TicketLocationService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IHelpMenuService, HelpMenuService>();
builder.Services.AddScoped<IProgrammeService, ProgrammeService>();
builder.Services.AddScoped<IShowCategoryService, ShowCategoryService>();
builder.Services.AddScoped<IShowService, ShowService>();

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
