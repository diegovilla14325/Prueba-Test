using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Repositories;
using Repository.Repositories.Company;
using Repository.Repositories.Security;
using Service.IService.Company;
using Service.IService.Security;
using Service.Service.Company;
using Service.Service.Security;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);


builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<TransactionsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<RewardRepository>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Servicio de autenticación JWTBearer
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true, //Le asignamos tiempo de expiración al token
            ValidateIssuerSigningKey = true, //Validar firma con llave privada
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["KeyJWT"])), //Configurar la firma con una llave
            ClockSkew = TimeSpan.Zero //Para que no exista discrepancias de tiempos si el token venció
        });
builder.Services.AddMemoryCache();




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
app.UseRouting();
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
