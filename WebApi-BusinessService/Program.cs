using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Web.Mvc;
using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Model;
using WebApi_BusinessService.Models;
using WebApi_BusinessService.Repos;
using WebApi_BusinessService.Utils.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});
IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddCors();


// Add services to the container.
builder.Services.AddControllers(config => {
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ClockSkew = TimeSpan.Zero
    };
    options.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS_TOKEN_EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddDbContext<AuthDbContext1>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("JWT"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//Service injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRecordRepo, RecordRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CustomAuthenticationFilter>();

var app = builder.Build();

app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<AuthenticateMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
