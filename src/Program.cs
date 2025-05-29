using CRM.NexPolicy.src.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CRM.NexPolicy.src.DataLayer.Repository.Agent;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ServiceLayer.Customer;
using CRM.NexPolicy.src.DataLayer.Repository.Customer;
using CRM.NexPolicy.src.DataLayer.Repository.LeadRepository;
using CRM.NexPolicy.src.DataLayer.Repository.ReferenceDataRepository;
using CRM.NexPolicy.src.ServiceLayer.ReferenceDataService;
using CRM.NexPolicy.src.ServiceLayer.LeadServices;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=JEVISPC\\MSSQLSERVERLOCAL;Database=CRM.NexPolicy;Trusted_Connection=True;TrustServerCertificate=True;";
// Add DbContext with connection from config
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositories
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IReferenceDataRepository, ReferenceDataRepository>();

// Services
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILeadService,LeadService>();
builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();

// Controllers and JSON config
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
