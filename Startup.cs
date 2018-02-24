using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DbConnection
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true);

            Configuration = build.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Add(new ServiceDescriptor(typeof(IMySqlContext), new MySqlContext(Configuration.GetConnectionString("MySqlServerConnectionString"))));
            services.Add(new ServiceDescriptor(typeof(IPostgresContext), new PostgresContext(Configuration.GetConnectionString("PostgresSqlServerConnectionString"))));
            services.Add(new ServiceDescriptor(typeof(ISqlServerContext), new SqlServerContext(Configuration.GetConnectionString("SqlServerConnectionString"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
