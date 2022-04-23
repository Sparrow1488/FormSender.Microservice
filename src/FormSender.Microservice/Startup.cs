using FormSender.Microservice.Data;
using FormSender.Microservice.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace FormSender.Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "FormSender", Version = "v1" }));
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddDbContext<ApplicationDbContext>(opt => UseSqlServer(opt));
            services.AddTransient<IMessageFormsRepository, MessageFormsRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FormSender v1"));
            app.UseSerilogRequestLogging();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private DbContextOptionsBuilder UseSqlServer(DbContextOptionsBuilder builder) =>
            builder.UseSqlServer(Configuration.GetConnectionString("Connection"));
    }
}