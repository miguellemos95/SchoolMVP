using SchoolAPI;
using Application;
using Persistence;
using Auth;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddAPI()
    .AddApplication()
    .AddPersistence()
    .AddAuth();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();