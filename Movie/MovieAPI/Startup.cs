using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movie.Domain.Interfaces;
using Movie.Infra.EfCore;
using Movie.Infra.Services;
using Movie.Infra.Validators;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using System;
using System.Text;

namespace MovieAPI
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMovieTheaterDao, MovieTheaterDao>();
            services.AddScoped<IAddressDao, AddressDao>();
            services.AddScoped<IAddressValidator, AddressValidator>();
            services.AddScoped<IMovieTheaterManagerDao, MovieTheaterManagerDao>();
            services.AddScoped<ISessionDao, SessionDao>();
            services.AddScoped<IMovieDao, MovieDao>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieTheaterService, MovieTheaterService>();
            services.AddScoped<IMovieTheaterDaoValidator, MovieTheaterDaoValidator>();
            services.AddScoped<ISessionValidator, SessionValidator>();
            services.AddScoped<IMovieTheaterManagerService, MovieTheaterManagerService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IMovieTheaterManagerValidator, MovieTheaterManagerValidator>();
            services.AddDbContext<AppDbContext>(options => 
                                                options.UseLazyLoadingProxies()
                                                .UseMySQL(Configuration
                                                .GetConnectionString("DataBaseConnection")));
            services.AddControllers();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajjsd09asjd09sajcnzxn")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
