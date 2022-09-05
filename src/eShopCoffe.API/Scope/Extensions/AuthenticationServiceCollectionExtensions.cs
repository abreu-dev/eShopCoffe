using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eShopCoffe.API.Scope.Extensions
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static void AddEShopCoffeAuthentication(this IServiceCollection services)
        {
            services.AddSingleton<IJwtSettings, JwtSettings>();

            var jwtSettings = new JwtSettings();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void UseIdentityAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
