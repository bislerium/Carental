using Carental.Configuration;
using Carental.Infrastructure.Identity;
using Carental.Infrastructure.Persistence;
using Carental.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddConfigurations();

#region Clean Architecture Layer Registration

builder.Services.AddConfigurationOptions(builder.Configuration);
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddInfrastructureIdentity(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

#endregion

#region Auth Configuration with JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var section = builder.Configuration.GetSection("Jwt");
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = section["Issuer"],
        ValidAudience = section["Audience"],
        //ValidAudiences = section.GetValue<string[]>("Audiences"),       
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section["Key"]!)),
        ClockSkew = TimeSpan.FromMinutes(section.GetValue<double>("SkewInMinutes")),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

#endregion

#region Endpoint Registration

builder.Services.AddHealthChecks();
builder.Services.AddControllers();

#endregion

#region Swagger configuration

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    //option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
