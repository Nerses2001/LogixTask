using BusinessLayer.IServices;
using BusinessLayer.Services;
using ClassMateLogix.Extansions;
using ClassMateLogix.Middleware;
using DataLayer;
using DataLayer.IRepository;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options =>
options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    ));

builder.Services.AddRouting();


// builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();


// builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
// builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IUserCourseService, UserCourseService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddRouting();


builder.Services.AddAutoMapperService();
builder.Services.AddIdentityServer();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();

var app = builder.Build();

var routeBuilder = new RouteBuilder(app);

routeBuilder.MapRoute("controller", async context =>
{
    await context.Response.WriteAsync("{controller} template");
});

routeBuilder.MapRoute("{controller}/{action}", async context =>
{
    await context.Response.WriteAsync("{controller}/{action} template");
});

app.UseRouting(); 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "House Booking");
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<TokenManagerMiddleware>();

app.MapControllers();

app.Run();
