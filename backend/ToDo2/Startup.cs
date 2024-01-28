using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDo2.Filters;
using ToDo2.Interfaces;
using ToDo2.Models;
using ToDo2.Services;

namespace ToDo2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("TodoDatabase")));

            // inject the service we created
            services.AddScoped<TodoListService>();

            services.AddScoped<TestDIService>();

            // 3 types of dependency injection
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();

            // dependency injection IOC(inverse of control)
            services.AddScoped<ITodoListService, TodoLinqService>();

            // async await demo
            services.AddScoped<AsyncService>();

            // async await GET and POST demo
            services.AddScoped<TodoAsyncService>();

            // normally HttpContext can be accessed in controller but not other class
            // add this in order for HttpContext to access in other place
            // to access user login info
            services.AddHttpContextAccessor();


            //cookie login
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            //{
            //    //未登入時會自動導到這個網址
            //    option.LoginPath = new PathString("/api/Login/NoLogin");

            //    //沒有權限時會自動導到這個網址
            //    option.AccessDeniedPath = new PathString("/api/Login/NoAccess");

            //    //Set login expire time
            //    // option.ExpireTimeSpan = TimeSpan.FromSeconds(2);
            //});

            //JWT token login
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidateAudience = true,
            //        ValidAudience = Configuration["Jwt:Audience"],
            //        ValidateLifetime = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:KEY"]))
            //    };
            //});


            // all controller must login first before access
            services.AddMvc(options =>
            {
                //options.Filters.Add(new AuthorizeFilter());
                //options.Filters.Add(new TodoAuthorizationFilter());
                //options.Filters.Add(typeof(TodoActionFilter));
                options.Filters.Add(typeof(TodoResultFilter));
            });

            // UNCOMMENT THIS WHEN YOU WANT TO WORK WITH API POST BECAUSE OF THE LOOPING BUG, child key-> parent key ->child key->...
            //services.AddControllers().AddJsonOptions(x =>
            //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            ////順序要一樣
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //use static route from POSTman
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
