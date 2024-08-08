using GraphQL_POC;
using GraphQL.SystemTextJson;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/query", async () =>
{
    var schema = new Schema { Query = new Query() };

    var json = await schema.ExecuteAsync(_ =>
    {
        _.Query = "{ patient { id firstName} }";
    });

    return json;
})
.WithName("Query")
.WithOpenApi();

app.Run();
