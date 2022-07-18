using Todo.Api.Extensions;
using Todo.Api.Extensions.Middlewares;
using Todo.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddIdentity();
builder.Services.RegisterServices();

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var AllowCorsForList = configuration.GetSection("AllowCorsForList").Value.Split(',');

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins(AllowCorsForList)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("Content-Disposition", "Content-Length"); ;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


builder.Services.BuildServiceProvider().MigrateDBSeedData(configuration);

app.UseMiddleware<ErrorHandlerMiddleware>();
app.Run();





