using DeslocamentoAPI.Data.Context;
using DeslocamentoAPI.Data.Repository;
using DeslocamentoAPI.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApplicationDbContext"),
        b => b.MigrationsAssembly("DeslocamentoAPI.Data"));
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var appAssemblie = typeof(DeslocamentoAPI.Application.Documentos.Commands.CriarCarro.CriarCarroCommand).Assembly;
builder.Services.AddMediatR(appAssemblie);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
