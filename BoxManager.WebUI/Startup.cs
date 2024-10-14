using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Aplitt.NEXTA.Studio.WebUI;

public class Startup
{
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            // options.Filters.Add<HttpResponseExceptionFilter>(int.MaxValue);
        });

        //services.AddAutoMapper(
        //    Assembly.GetAssembly(typeof(AutoMapperSharedStepConfig)));

        //services.AddDbContext<WarehouseManagerContext>(options =>
        //    options.EnableSensitiveDataLogging(true)
        //    //.UseNpgsql(Configuration.GetConnectionString("DefaultConnection") ?? string.Empty
        //    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection") ?? string.Empty
        //    .ToString()));

        services.AddAuthentication(o =>
        {
            o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.ExpireTimeSpan = System.TimeSpan.FromMinutes(600);
            options.AccessDeniedPath = new PathString(string.Empty);

            options.LoginPath = string.Empty;
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
        });

        services.AddHttpContextAccessor();

        services.AddControllersWithViews();

        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/dist";
        });

        services.AddAuthorization(options =>
        {
            //options.AddPolicy("Administrator", policy =>
            //{
            //    policy.RequireClaim(
            //        //CustomClaimTypesConsts.Roles,
            //        //RolesEnum.Administrator.ToString());
            //});

            //options.AddPolicy(CustomPolicy.Warehouseman, policy =>
            //{
            //    policy.RequireClaim(
            //        CustomClaimTypesConsts.Roles,
            //        RolesEnum.Administrator.ToString(),
            //        RolesEnum.Warehouseman.ToString());
            //});

            //options.AddPolicy(CustomPolicy.Contractor, policy =>
            //{
            //    policy.RequireClaim(
            //        CustomClaimTypesConsts.Roles,
            //        RolesEnum.Administrator.ToString(),
            //        RolesEnum.Contractor.ToString());
            //});

            //options.AddPolicy(CustomPolicy.AllUsers, policy =>
            //{
            //    policy.RequireClaim(
            //        CustomClaimTypesConsts.Roles,
            //        RolesEnum.Administrator.ToString(),
            //        RolesEnum.Contractor.ToString(),
            //        RolesEnum.Warehouseman.ToString());
            //});
        });

        services.AddHealthChecks();

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.Secure = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
            options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        if (!env.IsDevelopment())
        {
            app.UseSpaStaticFiles();
        }

        app.UseRouting();
        app.UseCookiePolicy();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
        });
        app.UseHealthChecks("/health");
        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (env.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
            }
        });
    }
}