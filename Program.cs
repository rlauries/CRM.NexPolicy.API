using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ServiceLayer.Customer;
using CRM.NexPolicy.src.ServiceLayer.ReferenceDataService;
using CRM.NexPolicy.src.ServiceLayer.LeadServices;
using CRM.NexPolicy.src.ServiceLayer.AgencyServices;
using CRM.NexPolicy.src.ServiceLayer.AuthServices;
using CRM.NexPolicy.src.ViewLayer.DTOs.Settings;
using CRM.NexPolicy.src.ServiceLayer.UploadImageServices;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.DataLayer.Repository.AgencyRepository;
using CRM.NexPolicy.src.DataLayer.Repository.AgentRepository;
using CRM.NexPolicy.src.DataLayer.Repository.AuthRepository;
using CRM.NexPolicy.src.DataLayer.Repository.CustomerRepository;
using CRM.NexPolicy.src.DataLayer.Repository.LeadRepository;
using CRM.NexPolicy.src.DataLayer.Repository.ReferenceDataRepository;
using CRM.NexPolicy.src.DataLayer.Repository.UserRepository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=JEVISPC\\MSSQLSERVERLOCAL;Database=CRM.NexPolicy;Trusted_Connection=True;TrustServerCertificate=True;";
// Add DbContext with connection from config
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IReferenceDataRepository, ReferenceDataRepository>();

// Services
builder.Services.AddScoped<IUploadProfileImageService, UploadProfileImageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAgencyService, AgencyService>();
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
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
