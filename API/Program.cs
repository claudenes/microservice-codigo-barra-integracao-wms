using AutoMapper;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using API.Endpoints;
using Data.Context;
using Domain.Interface.Repository;
using Data.Repository;
using Domain.Interface.Service;
using Service;
using API;
using MCar.Observability.Lib;
using MCar.EventBusRabbitMQ;
using MCar.EventBus.Abstractions;
using API.Handlers;

var builder = WebApplication.CreateBuilder(args);

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

builder.Services.AddDbContext<CentralDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("BASE_SQL")!,
               sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.EnableRetryOnFailure();
               });

});

builder.Services.AddCors(options => options.AddPolicy("PermitirApiRequest", builder => builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()));


builder.Services.AddScoped(typeof(ICentralRepository), typeof(CentralRepository));
builder.Services.AddScoped(typeof(IUnitOfWorkCentral), typeof(UnitOfWorkCentral));

builder.Services.AddTransient<IIntegracaoService, IntegracaoService>();

builder.Services.AddTransient<CodigoBarraIntegrarWmsEventHandler>();


builder.Services.AddCors(options =>
options.AddPolicy("PermitirApiRequest", builder => builder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "microservice-codigo-barra-integracao-wms V1",
            Version = "v1"
        });



    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    setup.IncludeXmlComments(xmlPath);


});


builder.Services.AddJaegerTracing("microservice-codigo-barra-integracao-wms");

builder.Services.AddRabbitMQ(
    new RabbitMQueuedOptions(
        Environment.GetEnvironmentVariable("MESSAGEQ_HOST"),
        Environment.GetEnvironmentVariable("MESSAGEQ_USER"),
        Environment.GetEnvironmentVariable("MESSAGEQ_PWD"),
        retryCount: 5,
        Environment.GetEnvironmentVariable("MESSAGEQ_CLIENT_NAME")));

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<CodigoBarraIntegrarWmsEvent, CodigoBarraIntegrarWmsEventHandler>();


app.UseCors(builder => builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());


app.UseSwagger();
app.UseSwaggerUI(c =>
                 {
                     c.SwaggerEndpoint("/swagger/v1/swagger.json", "microservice-codigo-barra-integracao-wms V1");
                     c.DocExpansion(DocExpansion.List);
                 }
);

app.UseHttpsRedirection();





//Commands
app.MapMethods(IntegrarCodigoBarra.Template, IntegrarCodigoBarra.Methods, IntegrarCodigoBarra.Handle);


app.Run();