using Contact.Api.Logger;
using Contact.Api.Middleware;
using Contact.DataAccess.Repository;
using Contact.Service.Contract;
using Contact.Service.Implementation;
using JsonFlatFileDataStore;
using NLog;

namespace Contact.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), Configuration["file"]);
            services.AddSingleton<IDataStore>(new DataStore(jsonFilePath, keyProperty: Configuration["DataStore:IdField"],
            reloadBeforeGetCollection: Configuration.GetValue<bool>("DataStore:EagerDataReload")));
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerManager logger)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.ConfigureExceptionHandler(logger);
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
