using CRM.NexPolicy.src.DataLayer.Repository.Lead;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.ServiceLayer.Lead;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CRM.NexPolicy.src.DataLayer.Repository.Agent;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ServiceLayer.Customer;
using CRM.NexPolicy.src.DataLayer.Repository.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=JEVISPC\\MSSQLSERVERLOCAL;Database=CRM.NexPolicy;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
