using Tekton.Examen.Application.Features;
using Tekton.Examen.Cross.Common;
using Tekton.Examen.Cross.Mapper;
using Tekton.Examen.Cross.Logging;

using Tekton.Examen.Persistence;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Tekton.Examen.Application.Interface.Features;
using Tekton.Examen.Application.Interface.Persistence;
using Tekton.Examen.Persistence.Repositories;
using Tekton.Examen.Application.Interface.Services;
using Tekton.Examen.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
builder.Services.AddHttpClient<IProductDiscountService, ProductDiscountService>();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddMemoryCache();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examen TEKTON", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<RequestTimingMiddleware>();

app.MapControllers();

app.Run();
