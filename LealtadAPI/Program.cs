using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Company;
using Service.IService.Company;
using Service.Service.Company;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(routing => routing.LowercaseUrls=true);
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<TransactionsRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var conectionString = builder.Configuration.GetConnectionString("Conection");
    options.UseMySQL(conectionString);
}
);
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
