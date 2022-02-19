using DataCollection.Models;
using DataCollection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

//Here we connect to swagger for testing.

namespace DataCollection
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddDbContext<PersonContext>(o => o.UseSqlite("Data source=people.db"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DataCollection", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                object p = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataCollection v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}




