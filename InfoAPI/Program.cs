using InfoAPI.Models;
using InfoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using InfoAPI.Authentication;
using Microsoft.AspNetCore.Authentication;



var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<PostgresSQLContext>();
// builder.Services.AddSingleton<IPerson, PersonService>();
builder.Services.AddScoped<IPerson, PersonService>();
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5173",
                                              "http://www.contoso.com");
                      });
});
builder.Services.AddControllers(config => 
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
// For Identity  
// builder.Services.AddIdentity<IdentityUser, IdentityRole>()  
//     .AddEntityFrameworkStores<ApplicationDbContext>()  
//     .AddDefaultTokenProviders();  
builder.Services
.AddAuthentication(CustomAuthenticationScheme.CustomScheme)
.AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>(CustomAuthenticationScheme.CustomScheme, o => {});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.UseHttpsRedirection();

app.UseAuthentication();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);


app.Run();

//------------------------------------------------------------------------------------------------------------//




record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}