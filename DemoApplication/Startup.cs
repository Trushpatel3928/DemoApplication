using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("corspolicy",
                corspolicybuilder =>
                {
                    corspolicybuilder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
                });
            });

            //services.AddSwaggerGen((options) =>
            //{
            //    options.SwaggerDoc("v1", new Info { Title = "SetUp API", Version = "v1" });
            //    options.AddSecurityDefinition("Bearer",
            //        new ApiKeyScheme
            //        {
            //            In = "header",
            //            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            //            Name = "Authorization",
            //            Type = "apiKey"
            //        });
            //    options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
            //        { "Bearer", Enumerable.Empty<string>() },
            //        });
            //});

            services.AddHttpContextAccessor();
            //services.AddScoped<GlobalRequestParams>();
            //services.AddScoped<IAppSettings, AppSettings>();
            //services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            //services.AddScoped<ILoginService, LoginService>();
            //services.AddScoped<ILoginRepository, LoginRepository>();
            //services.AddScoped<IApplicationUserService, ApplicationUserService>();
            //services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            //services.AddScoped<ISupportTicketService, SupportTicketService>();
            //services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
            //services.AddScoped<ITerminalService, TerminalService>();
            //services.AddScoped<ITerminalRepository, TerminalRepository>();
            //services.AddScoped<IEmailSendService, EmailSendService>();
            //services.AddScoped<ISetupService, SetupService>();
            //services.AddScoped<ISetupRepository, SetupRepository>();
            //services.AddScoped<IDashboardService, DashboardService>();
            //services.AddScoped<IDashboardRepository, DashboardRepository>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRSAUserService, RSAUserService>();
            //services.AddScoped<IRSAUserRepository, RSAUserRepository>();
            //services.AddScoped<IMarketService, MarketService>();
            //services.AddScoped<IMarketRepository, MarketRepository>();
            //services.AddScoped<IProviderService, ProviderService>();
            //services.AddScoped<IProviderRepository, ProviderRepository>();
            //services.AddScoped<IMarketaccessApiService, MarketaccessApiService>();
            //services.AddScoped<IReportFilterService, ReportFilterService>();
            //services.AddScoped<IReportFilterRepository, ReportFilterRepository>();

            //// BlobStroreTranspoter
            //services.AddScoped<IBlobStroreRepository, BlobStroreRepository>();
            // End

            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            //})
            //.ConfigureApiBehaviorOptions(o => { o.SuppressModelStateInvalidFilter = true; })
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Setup API v1");
        //    });

        //    app.UseCors("corspolicy");
        //    app.UseForwardedHeaders();

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    SqlMapperExtensions.TableNameMapper = (type) =>
        //    {
        //        do something here to pluralize the name of the type
        //         return type.Name;
        //        dynamic tableattr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
        //        var name = string.Empty;

        //        if (tableattr != null)
        //        {
        //            name = tableattr.Name;
        //        }

        //        return name;
        //    };

        //    middleware to read the headers from the request for Marketname and Profit Center
        //    app.Use(async (context, next) =>
        //    {
        //        ReadHeaders(context);
        //        await next.Invoke();
        //    });
        //    app.UseMvc();
        //}
        //private void ReadHeaders(HttpContext context)
        //{
        //    if (context.Request.Headers.ContainsKey("Authorization"))
        //    {
        //        string token = context.Request.Headers["Authorization"].ToString().Split(' ')[1];
        //        context.Items.Add(GlobalRequestParams.TOKEN_KEY, token);
        //    }
        //}
    }
}
