using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Domain.Entities.Configuration;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace Deloitte.Towers.Parking.Application.Api
{
    public partial class Startup
    {
        private AzureServiceTokenProvider azureServiceTokenProvider;
        private AzureAdConfiguration azureAdSecrets;
        private string keyvaulturl = ConfigurationManager.AppSettings["KeyVaultUrl"];

        public Startup()
        {
            azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(
            new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var obj = Task.Run(async () => await keyVaultClient.GetSecretAsync(keyvaulturl)).Result.Value;
            azureAdSecrets = Newtonsoft.Json.JsonConvert.DeserializeObject<AzureAdConfiguration>(obj.ToString());
        }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public async void ConfigureAuth(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = OpenIdConnectAuthenticationDefaults.AuthenticationType
            });

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {

                    Tenant = azureAdSecrets.IdaTenant,
                    Realm = azureAdSecrets.IdaAudienceOrAppIdUri,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidAudiences = new List<string> { azureAdSecrets.IdaAudienceOrAppIdUri },
                        ValidateIssuer = true,
                        ValidIssuers = new List<string> { azureAdSecrets.IdaIssuer },
                    },
                });

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = azureAdSecrets.IdaClient,
                    Authority = azureAdSecrets.IdaAuthority,

                    TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidAudiences = new List<string> { azureAdSecrets.IdaAudienceOrAppIdUri, azureAdSecrets.IdaClient },
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidIssuer = azureAdSecrets.IdaIssuer,
                    },
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        RedirectToIdentityProvider = (context) =>
                        {
                            var appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                            var idpRedirectUri = string.Format(azureAdSecrets.IdaRedirectUriPattern, context.Request.Host.Value + context.Request.PathBase.Value);
                            context.ProtocolMessage.RedirectUri = idpRedirectUri;
                            context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                            return Task.FromResult(0);
                        },
                    }
                });

            app.SetDefaultSignInAsAuthenticationType(OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }
    }
}
