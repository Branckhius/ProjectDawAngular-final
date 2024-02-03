using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Repositories.StudentRepository;
using ProjectDawAngular.Repositories.CourseRepository;
using ProjectDawAngular.Repositories.DepartmentRepository;
using ProjectDawAngular.Repositories.ProfessorDetailsRepository;
using ProjectDawAngular.Repositories.ProfessorRepository;
using ProjectDawAngular.Repositories.StudentCourseRepository;
using ProjectDawAngular.Data;
using ProjectDawAngular.Helpers.Extensions;
using ProjectDawAngular.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Adaugă servicii la container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configurează pipeline-ul pentru cererile HTTP.
Configure(app, builder.Environment);

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllersWithViews();
    services.AddDbContext<Lab4Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    services.AddRepositories();
    services.AddServices();
    services.AddHelpers();
    services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddScoped<ICourseRepository, CourseRepository>();
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    services.AddScoped<IProfessorDetailsRepository, ProfessorDetailsRepository>();
    services.AddScoped<IProfessorRepository, ProfessorRepository>();
    services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
}

static void Configure(WebApplication app, IHostEnvironment environment)
{
    if (!environment.IsDevelopment())
    {
        app.UseHsts();
    }
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllerRoute(
        name: "api",
        pattern: "api/{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");
}
