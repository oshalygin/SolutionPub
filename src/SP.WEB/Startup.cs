using AutoMapper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using SP.BLL;
using SP.DAL;
using SP.Entities;
using SP.Twitter;
using SP.WEB.Models;
using SP.WEB.Services;

namespace SP.WEB
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder().SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<BlogContext>(
                    options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();
    
            services.AddMvc()
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IPostBLL, PostBLL>();
            services.AddTransient<ITagBLL, TagBLL>();
            services.AddTransient<IImageBLL, ImageBLL>();
            services.AddTransient<ITwitterBLL, TwitterBLL>();
            services.AddTransient<ICommentBLL, CommentBLL>();
            services.AddTransient<IPostDataAccess, PostDataAccess>();
            services.AddTransient<ITagDataAccess, TagDataAccess>();
            services.AddTransient<IImageUtility, ImageUtility>();
            services.AddTransient<IImageDataAccess, ImageDataAccess>();
            services.AddTransient<ITwitterResourceAccess, TwitterResourceAccess>();

            //TwitterAPI DI
            services.AddTransient<ITwitterApi, TwitterApi>();
            services.AddTransient<ITimelineSettings, TimelineSettings>();
            services.AddTransient<IAuthenticationSettings, AuthenticationSettings>();
            services.AddTransient<IDataRequest, DataRequest>();
            services.AddTransient<IAuthenticate, Authenticate>();

        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
            }

            app.UseDeveloperExceptionPage();
            
            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseIdentity();

            Mapper.Initialize(configuration =>
            configuration.AddProfile<MappingProfile>());
            

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}