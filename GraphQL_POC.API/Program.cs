using GraphQL_POC;
using GraphQL_POC.Infrastructure;
using GraphQL_POC.Infrastructure.Repositories;
using GraphQL_POC.Infrastructure.Repositories.Interfaces;
using GraphQL.SystemTextJson;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<DefaultQuery>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Migration.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
