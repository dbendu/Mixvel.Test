using MixvelTest.Api.Controllers.Routes.Search;
using MixvelTest.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services
    .AddRoutesSearchController()
    .AddServices(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();