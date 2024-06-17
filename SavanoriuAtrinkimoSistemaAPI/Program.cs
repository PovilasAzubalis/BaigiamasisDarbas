using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>(_ => new DatabaseRepository("Data Source=DESKTOP-6FFNPQ7;Initial Catalog=VolunteerDB_Dapper;Integrated Security=True;Encrypt=False"));
builder.Services.AddTransient<ManagmentService>();

builder.Services.AddSwaggerGen();

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
