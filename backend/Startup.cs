using CountriesChallenge.Domain.Interfaces;
using CountriesChallenge.Infra;
using CountriesChallenge.Infra.Repositories;
using CountriesChallenge.Middleware;
using CountriesChallenge.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CountriesChallenge
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "FrontEnd";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //var connectionString = Configuration.GetConnectionString("CountryChallengeCn");
            //services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

            services.AddDbContext<Context>(options => options.UseInMemoryDatabase("CountryChallenge"));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            
            services.AddCors(options =>
            {
            options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CountriesChallenge.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CountriesChallenge.Api v1"));
            }

            app.UseHttpsRedirection();

            //app.UseMiddleware<BasicAuthenticationMiddleware>();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
