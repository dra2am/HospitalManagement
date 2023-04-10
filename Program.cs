using HospitalManagement.Data;
using HospitalManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//add controllers then map on line 40
builder.Services.AddControllers();
//add services (change this for proper dependency injection with an interface.)
builder.Services.AddScoped<PatientService>();
//this is for swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SQL connection, connection string from appsettings.json
builder.Services.AddDbContext<HospitalContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
