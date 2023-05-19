using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Application.UseCase;
using Infraestructure.Command;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IMercaderiaServices, MercaderiaServices>();
builder.Services.AddScoped<IMercaderiaCommand, MercaderiaCommand>();
builder.Services.AddScoped<IMercaderiaQuery, MercaderiaQuery>();
builder.Services.AddScoped<IComandaServices, ComandaServices>();
builder.Services.AddScoped<IComandaCommand, ComandaCommand>();
builder.Services.AddScoped<IComandaQuery, ComandaQuery>();
builder.Services.AddScoped<IFormaEntregaServices, FormaEntregaServices>();
builder.Services.AddScoped<IFormaEntregaCommand, FormaEntregaCommand>();
builder.Services.AddScoped<IFormaEntregaQuery, FormaEntregaQuery>();
builder.Services.AddScoped<IComandaMercaderiaServices, ComandaMercaderiaServices>();
builder.Services.AddScoped<IComandaMercaderiaCommand, ComandaMercaderiaCommand>();
builder.Services.AddScoped<IComandaMercaderiaQuery, ComandaMercaderiaQuery>();
builder.Services.AddScoped<ITipoMercaderiaServices, TipoMercaderiaServices>();
builder.Services.AddScoped<ITipoMercaderiaCommand, TipoMercaderiaCommand>();
builder.Services.AddScoped<ITipoMercaderiaQuery, TipoMercaderiaQuery>();

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
