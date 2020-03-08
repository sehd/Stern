using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SigmaSharp.Stern.Web.Models.Authentication;
using SigmaSharp.Stern.Web.Persistance;
using System;
using System.Text;

namespace SigmaSharp.Stern.Web
{
    static class ConfigurationExtensions
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            const string AuthConfigSectionName = "Authentication";
            services.Configure<AuthenticationOptions>(
                configuration.GetSection(AuthConfigSectionName));

            var config = configuration.GetSection(AuthConfigSectionName).Get<AuthenticationOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<CoreDbContext>()
                            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = config.ShouldValidateIssuer,
                    ValidateAudience = config.ShouldValidateAudience,
                    ValidAudience = config.Audience,
                    ValidIssuer = config.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecurityKey))
                };
            });
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDbContext>(options =>
            {
                var connectionString = configuration.GetValue<string>("DataAccess:DefaultConnectionString");
                var dbType = configuration.GetValue<DbProviderType>("DataAccess:DbProviderType");
                switch (dbType)
                {
                    case DbProviderType.SQLite:
                        options.UseSqlite(connectionString);
                        break;
                    case DbProviderType.SQLServer:
                        options.UseSqlServer(connectionString);
                        break;
                    default:
                        throw new FormatException("Db type does not exists or is not recognized");
                };
            });
        }
    }
}
