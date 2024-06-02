using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RestaurantReservation;
using RestaurantReservation.Db;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var tokenValidation = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["JWTToken:Issuer"],
    ValidAudience = builder.Configuration["JWTToken:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:Key"]))
};

builder.Services.AddSingleton(tokenValidation);




builder.Services.AddSwaggerGen(c =>
 {

     // Add security definition for Bearer token
     c.AddSecurityDefinition("RestaurantApiBearerAuth", new()
     {
         Type = SecuritySchemeType.Http,
         Scheme = "Bearer",
         Description = "Input a valid token to access this API"
     });

     c.AddSecurityRequirement(new()
    {
        {
            new ()
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "RestaurantApiBearerAuth" }
            },
            new List<string>()
        }
    });
 });



builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("Customer", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Type", "Customer");
    });

    op.AddPolicy("Employee", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Type", "Employee");
        policy.RequireClaim("Position", Position.Normal.ToString());
    });

    op.AddPolicy("Manager", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Type", "Employee");
        policy.RequireClaim("Position", Position.Manager.ToString());
    });

});



builder.Services.AddAuthentication("Bearer").AddJwtBearer(p =>
{
    p.SaveToken = true;
    p.TokenValidationParameters = tokenValidation;
});





builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<RestaurantReservationDbContext>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<RestaurantRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<TableRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderItemRepository>();
builder.Services.AddScoped<MenuItemRepository>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
