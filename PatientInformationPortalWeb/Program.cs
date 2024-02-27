using Microsoft.EntityFrameworkCore;
using PatientInformationPortalWeb.Data;
using PatientInformationPortalWeb.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDiseaseInformationRepository,DiseaseInformationRepository>();
builder.Services.AddScoped<INCDRepository, NCDRepository>();
builder.Services.AddScoped<IAllergiesRepository, AllergiesRepository>();
builder.Services.AddScoped<IPatientInformationRepository, PatientInformationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PatientInformation}/{action=Index}/{id?}");

app.Run();
