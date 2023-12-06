using EduCenter.Application;
using EduCenter.Infrastructure;
using EduCenter.Infrastructure.Peristance;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers().AddJsonOptions(config => config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Docker")));

builder.Services.AddMemoryCache();

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = "Issuer",
//            ValidateAudience = true,
//            ValidAudience = "Audience",
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asosiyUser711w15ed16516w6e51de65f1ef1e6f51ef51"))
//        };
//    });

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();

app.Run();
