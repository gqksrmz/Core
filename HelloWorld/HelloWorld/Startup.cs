using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace HelloWorld
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath).AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
            _configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//注册MVC服务
            services.AddDbContext<DataContext>(options =>
            {
                //var connectionString= _configuration["ConnectionStrings:DefaultConnection"];
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<IdentityDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("HelloWorld"));
                });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireDigit = false;//需要数值
                options.Password.RequireLowercase = false;//需要小写字母
                options.Password.RequireNonAlphanumeric = false;//需要非字母和数字类型
                options.Password.RequireUppercase = false;//需要大写字母
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //User settings
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //开发者模式
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseWelcomePage();
            //app.UseDefaultFiles();
            // app.UseStaticFiles();
            app.UseFileServer();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            });
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();//给定一个默认的路由规则，允许我们访问 HomeController
            app.UseMvc(ConfigurationRoute);
            app.Run(async (context) =>
            {
                //throw new System.Exception("Throw Exception");
                var msg = Configuration["message"];
                await context.Response.WriteAsync(msg);
            });
        }
        private void ConfigurationRoute(IRouteBuilder routeBuilder)
        {
            //Home/Index
            routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");

        }
    }
}
