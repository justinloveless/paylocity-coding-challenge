using API.Interfaces;
using API.Repositories;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISqlService, SqlService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDependantRepository, DependantRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDependantService, DependantService>();
builder.Services.AddScoped<IDeductionCalculatorService, DeductionCalculatorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(optBuilder => optBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//.WithOrigins("https://localhost:4200"));


app.UseAuthorization();

// if (!app.Environment.IsDevelopment())
// {
    app.UseDefaultFiles();
    app.UseStaticFiles();
// }

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToController("Index", "Fallback");
});

app.Run();