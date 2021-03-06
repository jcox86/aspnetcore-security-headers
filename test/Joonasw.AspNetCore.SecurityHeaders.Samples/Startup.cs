﻿using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp;
using Joonasw.AspNetCore.SecurityHeaders.Hsts;
using Joonasw.AspNetCore.SecurityHeaders.Samples.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Joonasw.AspNetCore.SecurityHeaders.Samples
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setup mapping from config file to configuration
            services.Configure<HstsOptions>(Configuration.GetSection("Hsts"));
            services.Configure<CspOptions>(Configuration.GetSection("Csp"));
            services.Configure<HpkpOptions>(Configuration.GetSection("Hpkp"));

            // Add framework services.
            services.AddMvc();

            // Add CSP nonce support
            services.AddCsp(nonceByteAmount: 32);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHttpsEnforcement();

                app.UseHsts();
                // Manual configuration
                //app.UseHsts(new HstsOptions(TimeSpan.FromDays(30), includeSubDomains: false, preload: false));

                app.UseHpkp();
                // Manual configuration
                //app.UseHpkp(hpkp =>
                //{
                //    hpkp.UseMaxAgeSeconds(30 * 24 * 60 * 60)
                //        .AddSha256Pin("nrmpk4ZI3wbRBmUZIT5aKAgP0LlKHRgfA2Snjzeg9iY=")
                //        .SetReportOnly()
                //        .ReportViolationsTo("/hpkp-report");
                //});
            }

            app.UseStaticFiles();

            app.UseCsp();

            // Manual configuration
            //app.UseCsp(csp =>
            //{
            //    //csp.EnableSandbox()
            //    //    .AllowScripts();
            //    csp.AllowScripts
            //        .FromSelf()
            //        .From("localhost:1591")
            //        .From("ajax.aspnetcdn.com")
            //        .AddNonce();

            //    csp.AllowStyles
            //        .FromSelf()
            //        .From("ajax.aspnetcdn.com")
            //        .AddNonce();

            //    csp.AllowImages
            //        .FromSelf();

            //    csp.AllowAudioAndVideo
            //        .FromNowhere();

            //    csp.AllowFrames
            //        .FromNowhere();

            //    csp.AllowWorkers
            //        .FromNowhere();

            //    csp.AllowConnections
            //        .To("ws://localhost:1591")
            //        .To("http://localhost:1591")
            //        .ToSelf();

            //    csp.AllowFonts
            //        .FromSelf()
            //        .From("ajax.aspnetcdn.com");

            //    csp.AllowPlugins
            //        .FromNowhere();

            //    csp.AllowFraming
            //        .FromNowhere();

            //    csp.SetReportOnly();
            //    csp.ReportViolationsTo("/csp-report");
            //    csp.SetUpgradeInsecureRequests(); //Upgrade HTTP URIs to HTTPS

            //    csp.OnSendingHeader = context =>
            //    {
            //        context.ShouldNotSend = context.HttpContext.Request.Path.StartsWithSegments("/api");
            //        return Task.CompletedTask;
            //    };
            //});

            app.UseXFrameOptions();
            // Manual Configuration
            //app.UseXFrameOptions(new XFrameOptionsOptions(XFrameOptionsOptions.XFrameOptionsValues.Deny));

            app.UseXXssProtection();
            // Manual Configuration
            //app.UseXXssProtection(new XXssProtectionOptions(false, false));

            app.UseXContentTypeOptions();
            // Manual Configuration
            //app.UseXContentTypeOptions(new XContentTypeOptionsOptions(true));

            app.UseReferrerPolicy();
            // Manual Configuration
            //app.UseReferrerPolicy(
            //    new ReferrerPolicyOptions(ReferrerPolicyOptions.ReferrerPolicyValues.NoReferrerWhenDowngrade));

            app.UseExpectCT();
            // Manual Configuration
            //app.UseExpectCT(
            //    new ExpectCTOptions(TimeSpan.FromSeconds(30), "/expect-ct-report", true));

            app.UseFeaturePolicy();
            // Manual Configuration
            //app.UseFeaturePolicy(fp =>
            //{
            //    fp.AllowGeolocation
            //        .FromSelf()
            //        .From("https://google.com");

            //    fp.AllowMidi
            //        .FromAnywhere();

            //    fp.AllowNotifications
            //        .FromSelf();

            //    fp.AllowPush
            //        .FromNowhere();

            //    fp.AllowSyncXhr
            //        .FromNowhere();

            //    fp.AllowMicrophone
            //        .FromAnywhere();

            //    fp.AllowCamera
            //        .FromNowhere();

            //    fp.AllowMagnetometer
            //        .FromSelf();

            //    fp.AllowGyroscope
            //        .FromSelf()
            //        .From("https://google.com")
            //        .From("https://www.yahoo.com");

            //    fp.AllowSpeaker
            //        .FromNowhere();

            //    fp.AllowVibrate
            //        .FromNowhere();

            //    fp.AllowFullscreen
            //        .FromSelf();

            //    fp.AllowPayment.
            //        FromNowhere();
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "csp-report",
                    template: "csp-report",
                    defaults: new { controller = "Report", action = "Csp" });

                routes.MapRoute(
                    name: "hpkp-report",
                    template: "hpkp-report",
                    defaults: new { controller = "Report", action = "Hpkp" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
