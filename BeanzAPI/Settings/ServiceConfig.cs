 
using Beanz.Core.AuthModule;
using Beanz.Core.AuthModule.AuthDatabaseEnsure;
using Beanz.Core.BeanzRoutes;
using Beanz.Data.Services.AuthModule;
using Beanz.Data.Services.AuthModule.AuthDatabaseEnsure;
using Beanz.Data.Services.BeanzRoutes;
using Beanz.DTOs.Common; 
using Beanz.API.Filters;
using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Beanz.API.Mapper; 
using Beanz.API.Security;
using Beanz.API.Settings; 
using Beanz.API.Services;
using Beanz.API.Services.ExternalServices;
using Beanz.API.StartupConfig;



//using Beanz.API.StartupConfig.ExertERP.Reports;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Office2016.Excel;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
//using System.Configuration;
using System.Text;

namespace Beanz.API
{

    public class ServiceConfig
    {


        public static void Register(WebApplicationBuilder builder )
        {
            IServiceCollection services = builder.Services;
            HttpContext httpContext = new DefaultHttpContext();  

            services.AddMvc(); 

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});


            // ✅ Custom model-validation response
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    return new BadRequestObjectResult(
                        ResponseDTO<object>.Fail("Invalid input", "VALIDATION", 400, errors));
                };
            });

            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = builder.Configuration["Google:ClientId"];
                    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
                    options.CallbackPath = "/api/Auth/google-callback";
                });

            //services.AddSingleton(Configuration);// enable Configuration Services 
            services.AddHttpContextAccessor();
            services.AddHttpClient<ISelfHttpClient, SelfHttpClient>();

            ////Settings -- use following line for IOptions<T> injection to  
            services.Configure<ApiSettings>(builder.Configuration.GetSection("Api"));
            services.Configure<ApiSecuritySettings>(builder.Configuration.GetSection("ApiSecurity"));
            services.Configure<InstaAPISettings>(builder.Configuration.GetSection("InstaAPI"));

            // Register Once AutoMapper and Inject in all controllers.
            var _mapper = AutoMapperConfig.Initialize().CreateMapper();
            services.AddSingleton(_mapper);
  
            services.AddScoped<ValidateIdAsyncActionFilter>();
            services.AddScoped<ValidatePagingAsyncActionFilter>(); 

            var secretConnectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
            Utilities.Configuration.ConnectionString = secretConnectionString;

 

            // ---------- Configuration bindings ----------
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

            Utilities.Configuration.CompanyID = 1;
            Utilities.Configuration.UserID = 1;
            Utilities.Configuration.LanguageID = 1;

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailVerificationTokenService, EmailVerificationTokenService>(); 
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<IMFARepository, MFARepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IExternalLoginRepository, ExternalLoginRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IGoogleTokenVerifier, GoogleTokenVerifier>();
            services.AddScoped<IAppleTokenVerifier, AppleTokenVerifier>();
            services.AddScoped<IMicrosoftTokenVerifier, MicrosoftTokenVerifier>();
            services.AddScoped<IFacebookTokenVerifier, FacebookTokenVerifier>();
            services.AddScoped<IGitHubTokenVerifier, GitHubTokenVerifier>();
            services.AddScoped<ILinkedInTokenVerifier, LinkedInTokenVerifier>();
            services.AddScoped<ITwitterTokenVerifier, TwitterTokenVerifier>();
            services.AddScoped<IAuthEnsureRepository, AuthEnsureRepository>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<IBeanzScriptRepository, BeanzScriptRepository>();
            services.AddScoped<IBeanzRepository, BeanzRepository>();
            services.AddScoped<IBeanzPermissionRepository, BeanzPermissionRepository>();
            services.AddScoped<ITotpService, TotpService>(); 

        }

        public static void Registerd(WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;

            // services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig")); 2024

            //var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
            //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Secret"]));
            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero, // with this we can set our token expire time in generatetoken without this the default expire time is 5 min
                ValidAudience = builder.Configuration.GetSection("JwtConfig")["Audiance"],
                ValidIssuer = builder.Configuration.GetSection("JwtConfig")["Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig")["Key"]))
            };

            //services.AddSingleton(tokenValidationParams);
            services.AddScoped<TokenValidationParameters>(_ => tokenValidationParams);
            //services.AddTransient(tokenValidationParams);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {

                jwt.SaveToken = true;
                jwt.RequireHttpsMetadata = false;
                jwt.TokenValidationParameters = tokenValidationParams;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(CookieAuthenticationDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                .Build());

                options.AddPolicy("ApiUserPolicy", new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    //.RequireClaim("JwtRole", "ID")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .Build());
            });

            //services.AddAuthorization();  // ye issue the humne ye line add ki thi ye line over ride kar rahi thi top three lines ko

            services.AddMvc();
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //.AddJsonOptions(opt => opt.JsonSerializerOptions..ContractResolver = new DefaultContractResolver());

            //services.AddMvcCore()
            // .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            // .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //ervices.AddTransient<IValidator<UserCredentialDTO>, UserCredentialDTOValidator>();
            //services.AddTransient<IValidator<BrandDTO>, BrandValidations>();

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddSingleton(Configuration);// enable Configuration Services 
            services.AddHttpContextAccessor();
            services.AddHttpClient<ISelfHttpClient, SelfHttpClient>();

            ////Settings -- use following line for IOptions<T> injection to  
            services.Configure<ApiSettings>(builder.Configuration.GetSection("Api"));
            services.Configure<ApiSecuritySettings>(builder.Configuration.GetSection("ApiSecurity"));
            services.Configure<InstaAPISettings>(builder.Configuration.GetSection("InstaAPI"));

            // Register Once AutoMapper and Inject in all controllers.
            var _mapper = AutoMapperConfig.Initialize().CreateMapper();
            services.AddSingleton(_mapper);



            //// configure basic authentication 
            ////services.AddAuthorization();

            //services.AddTransient<IBeanzAuthentication, BeanzAuthentication>();

            //services.AddSingleton<ValidateIdAsyncActionFilter>();
            //services.AddSingleton<ValidatePagingAsyncActionFilter>();
            //services.AddSingleton<ITestRepository, TestRepository>();

            services.AddScoped<ValidateIdAsyncActionFilter>();
            services.AddScoped<ValidatePagingAsyncActionFilter>();
            //services.AddScoped<ITestRepository, TestRepository>();

            var secretConnectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
            Utilities.Configuration.ConnectionString = secretConnectionString;



            Utilities.Configuration.InstaAPILink = builder.Configuration.GetSection("InstaAPI").GetSection("APILink").Value;
            Utilities.Configuration.XInstaAuth = builder.Configuration.GetSection("InstaAPI").GetSection("X-insta-auth").Value;
            Utilities.Configuration.hospital_name = builder.Configuration.GetSection("InstaAPI").GetSection("hospital_name").Value;
            //Utilities.Configuration.request_handler_key = "";

            Utilities.Configuration.CompanyID = 1;
            Utilities.Configuration.UserID = 1;
            Utilities.Configuration.LanguageID = 1;


            ////--------------------------Start------Administrations-------------------------------------
            //StartupConfig.Administrations.Dynamic.Dashboards.DynamicDashboards.Register(services);
            //StartupConfig.Administrations.Dynamic.Reports.DynamicReports.Register(services);
            //StartupConfig.Administrations.Dynamic.Setup.DynamicSetup.Register(services);
            //StartupConfig.Administrations.GeneralMasters.GeneralMasters.Register(services);
            //StartupConfig.Administrations.Security.Security.Register(services);

            StartupConfig.System.Setup.ses_Setup.Register(services);

            ////--------------------------------Administrations------End-------------------------------
            ////--------------------------Start------FinancialAccountingSystem-------------------------------------
            //StartupConfig.FinancialAccountingSystem.Dashboards.FinancialAccountingSystemDashboards.Register(services);
            //StartupConfig.FinancialAccountingSystem.Masters.FinancialAccountingSystemMasters.Register(services);
            //StartupConfig.FinancialAccountingSystem.Reports.FinancialAccountingSystemReports.Register(services);
            //StartupConfig.FinancialAccountingSystem.Transactions.FinancialAccountingSystemTransactions.Register(services);
            //StartupConfig.FinancialAccountingSystem.WorkflowSetup.FinancialAccountingSystemWorkflowSetup.Register(services);

            //--------------------------------FinancialAccountingSystem------End-------------------------------

            //--------------------------Start------HospitalInformationSystem-------------------------------------

            //StartupConfig.HospitalInformationSystem.Dashboards.BillingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.ClinicalInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.DailyActivities.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.FrontOfficeInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.LaboratoryInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.NursingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.PharmacyInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Dashboards.RadiologyInformationSystem.Register(services);

            //StartupConfig.HospitalInformationSystem.Masters.HospitalInformationSystemDailyActivities.Register(services);
            //StartupConfig.HospitalInformationSystem.Masters.HospitalInformationSystemMasters.Register(services);

            //StartupConfig.HospitalInformationSystem.Reports.BillingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.ClinicalInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.DailyActivities.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.FrontOfficeInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.LaboratoryInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.NursingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.PharmacyInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Reports.RadiologyInformationSystem.Register(services);

            //StartupConfig.HospitalInformationSystem.Transactions.BillingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.ClinicalInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.DailyActivities.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.FrontOfficeInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.LaboratoryInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.NursingInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.PharmacyInformationSystem.Register(services);
            //StartupConfig.HospitalInformationSystem.Transactions.RadiologyInformationSystem.Register(services);

            ////--------------------------------HospitalInformationSystem------End-------------------------------


            ////--------------------------Start------HumanResourceManagementSystem-------------------------------------
            StartupConfig.HummanResourceManagement.Masters.hrms_Masters.Register(services);
            StartupConfig.HummanResourceManagement.Policies.hrms_Policies.Register(services);
            StartupConfig.HummanResourceManagement.Statuses.hrms_Statuses.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Attendance.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Employees.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Leaves.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Loans.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Payrolls.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Dashboards.Vacations.Register(services);

            //StartupConfig.HumanResourceManagementSystem.Masters.HumanResourceManagementSystemMasters.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Setup.HumanResourceManagementSystemSetup.Register(services);

            //StartupConfig.HumanResourceManagementSystem.Reports.Allowances.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Attendance.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Employees.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Leaves.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Loans.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Payrolls.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Reports.Vacations.Register(services);

            //StartupConfig.HumanResourceManagementSystem.Transactions.Allowances.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Attendance.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Employees.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Leaves.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Loans.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Payrolls.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Vacations.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.Tickets.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.EndOfServices.Register(services);
            //StartupConfig.HumanResourceManagementSystem.Transactions.BusinessTrip.Register(services);


            ////--------------------------------HumanResourceManagementSystem------End-------------------------------

            ////--------------------------Start------SupplyChainManagment-------------------------------------
            //StartupConfig.SupplyChainManagment.Dashboards.SupplyChainManagmentDashboards.Register(services);
            //StartupConfig.SupplyChainManagment.Masters.SupplyChainManagmentMasters.Register(services);
            //StartupConfig.SupplyChainManagment.Reports.SupplyChainManagmentReports.Register(services);
            //StartupConfig.SupplyChainManagment.Transactions.SupplyChainManagmentTransactions.Register(services);
            //StartupConfig.SupplyChainManagment.WorkflowSetup.SupplyChainManagmentWorkflowSetup.Register(services);

            ////--------------------------------SupplyChainManagment------End-------------------------------

            ////--------------------------Start------SystemConfig-------------------------------------
            //StartupConfig.SystemConfig.SystemConfig.Register(services);

            ////--------------------------------SystemConfig------End-------------------------------

            ////--------------------------Start------OtherAreas-------------------------------------
            //StartupConfig.OtherAreas.eXertIntegrateConfig.Register(services);
            //StartupConfig.OtherAreas.OtherAreasConfig.Register(services);

            ////--------------------------------OtherAreas------End-------------------------------

            ////--------------------------Start------EmployeeSelfService-------------------------------------
            //StartupConfig.EmployeeSelfService.Transactions.EmployeeSelfServiceTransactions.Register(services);
            //StartupConfig.EmployeeSelfService.Masters.EmployeeSelfServiceMasters.Register(services);
            //StartupConfig.EmployeeSelfService.Dashboards.EmployeeSelfServiceDashboards.Register(services);
            //StartupConfig.EmployeeSelfService.Reports.EmployeeSelfServiceReports.Register(services);
            //StartupConfig.EmployeeSelfService.WorkflowSetup.EmployeeSelfServiceWorkflowSetup.Register(services);
            ////--------------------------------EmployeeSelfService------End-------------------------------

            ////--------------------------Start------DashboardsAndReports-------------------------------------
            //StartupConfig.DashboardsAndReports.Reports.Register(services);
            ////--------------------------------DashboardsAndReports------End-------------------------------

            ////--------------------------Start------Assign Policies-------------------------------------
            //StartupConfig.HumanResourceManagementSystem.Transactions.AssignPolicies.Register(services);
            ////--------------------------------Assign Policies------End-------------------------------

        }

    }
}
