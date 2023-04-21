using FluentValidation;
using HotWheelsApp.Domain;
using HotWheelsApp.Infrastructure;
using HotWheelsDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHotWheelsRepositary, HotWheelsRepositary>();
builder.Services.AddTransient<IValidator<HotWheel>,HotWheelValidator>();
builder.Services.AddDbContext<HotWheelsCollectionDbContext>
(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HotWheelsDb")));


builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
{
    p.AllowAnyMethod();
    p.SetIsOriginAllowed(s => new Uri(s).IsLoopback);
    p.WithHeaders(HeaderNames.ContentType);
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
