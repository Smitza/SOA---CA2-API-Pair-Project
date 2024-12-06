using GraphQL.AspNet.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using SOACA2.Models;

//new
using Microsoft.Data.SqlClient;
using ImplementAPIKeyAuthentication.Interface;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ApiKey.json", optional: true, reloadOnChange: true);


builder.Services.AddGraphQL();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Running into cycling problems, solution: https://medium.com/@zaynt.dev/a-possible-object-cycle-was-detected-157cf552efdf
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// New connection string
// string connectionString = app.Configuration.GetConnectionString("Server=tcp:team-fortress-2-server.database.windows.net,1433;Initial Catalog=TeamFortress2 Database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";")!;


builder.Services.AddDbContext<TFContext>(opt => opt.UseInMemoryDatabase("TFList"));

builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
builder.Services.AddScoped<ApiKeyValidation>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Manual seed of the DB
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TFContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseGraphQL();
app.Run();
