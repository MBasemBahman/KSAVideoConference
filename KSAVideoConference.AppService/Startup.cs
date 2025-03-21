using AutoMapper;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using KSAVideoConference.AppService.Hubs;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Repository;
using KSAVideoConference.Repository.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace KSAVideoConference.AppService
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
                    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbConnection")));
            services.AddScoped<AppUnitOfWork>();

            services.AddSignalR();

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("App", new OpenApiInfo { Title = "App APIs", Version = "1" });
                c.SwaggerDoc("User", new OpenApiInfo { Title = "User APIs", Version = "1" });
                c.SwaggerDoc("Group", new OpenApiInfo { Title = "Group APIs", Version = "1" });
                c.SwaggerDoc("GroupMember", new OpenApiInfo { Title = "Group Member APIs", Version = "1" });
                c.SwaggerDoc("GroupMessage", new OpenApiInfo { Title = "Group Message APIs", Version = "1" });
                c.SwaggerDoc("UserContact", new OpenApiInfo { Title = "User Contact APIs", Version = "1" });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddApiVersioning(config =>
            {
                // Specify the default API Version
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            AppMainData.DomainName = Configuration.GetValue<string>("DomainName");

            JToken jAppSettings = JToken.Parse(
                                  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));

            string googleCredential = jAppSettings["GoogleCredential"].ToString();

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(googleCredential)
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AppMainData.WebRootPath = env.ContentRootPath;

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploud")),
                RequestPath = new PathString("/Uploud")
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/App/swagger.json", "App APIs");
                c.SwaggerEndpoint("/swagger/User/swagger.json", "User APIs");
                c.SwaggerEndpoint("/swagger/Group/swagger.json", "Group APIs");
                c.SwaggerEndpoint("/swagger/GroupMember/swagger.json", "Group Member APIs");
                c.SwaggerEndpoint("/swagger/GroupMessage/swagger.json", "Group Message APIs");
                c.SwaggerEndpoint("/swagger/UserContact/swagger.json", "User Contact APIs");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AppHub>("/AppHub");
            });
        }
    }
}
