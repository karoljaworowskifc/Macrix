using Macrix.Contract.Configuration;
using Macrix.Repository;
using Macrix.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.Configure<DataConfiguration>(
    builder.Configuration.GetSection(DataConfiguration.DataConfigurationName));

builder.Services.Configure<DataConfiguration>(
    DataConfiguration.DataConfigurationName,
    builder.Configuration.GetSection("DataConfiguration"));

builder.Services.Configure<DataConfiguration>(
    builder.Configuration.GetSection(DataConfiguration.DataConfigurationName));

builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

builder.Services.AddSwaggerGen(s =>
{
  //  s.SwaggerDoc("macrix", new OpenApiInfo { Title = "Macrix test API", Version = "v1" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseSwagger();
app.UseSwaggerUI();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
   // options.RoutePrefix = string.Empty;
});

app.Run();
