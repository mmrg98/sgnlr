using Microsoft.EntityFrameworkCore;
using SgnlrServer.Data;
using SgnlrServer.HubConfig;
using SgnlrServer.Models;
using SgnlrServer.TimerFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddSignalR();

builder.Services.AddSingleton<TimerManager>();






builder.Services.AddDbContext<TravelDemoContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("TravelCon")));


builder.Services.AddControllers();
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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChartHub>("/chart");
app.MapHub<CustomerHub>("/customer");

app.Run();
