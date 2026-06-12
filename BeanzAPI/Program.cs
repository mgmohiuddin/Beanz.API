using Beanz.Core.AuthModule.AuthDatabaseEnsure;
using Beanz.DTOs.AuthModule.RequestResponse;
using Beanz.DTOs.Common; 
using Beanz.API.Controllers.AuthModule;
using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Beanz.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Beanz.API;


var builder = WebApplication.CreateBuilder(args);

// ---------- Services ----------
builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("Open", p =>
    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

//// 🔐 JWT
//var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!);
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//        ValidAudience = builder.Configuration["JwtSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ClockSkew = TimeSpan.Zero,
//    };

//    options.Events = new JwtBearerEvents
//    {
//        OnTokenValidated = context =>
//        {
//            var token = context.Request.Headers["Authorization"]
//                .ToString().Replace("Bearer ", "");
//            if (AuthController._blacklistedTokens.Contains(token))
//                context.Fail("Token is blacklisted.");
//            return Task.CompletedTask;
//        }
//    };
//});

// 1. Bind settings once
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()!;

//// 👇 Resolve secret: appsettings.json → env var → throw
//var secret = builder.Configuration["JwtSettings:Secret"]
//    ?? Environment.GetEnvironmentVariable("JWT_SECRET")
//    ?? throw new InvalidOperationException("JWT secret not configured");


//jwtSettings.Secret = secret; // keep the bound object in sync

var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!);

builder.Services.AddSingleton<IJWTService, JWTService>();
var keyBytes = Encoding.UTF8.GetBytes(jwtSettings.Secret);



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = jwtSettings.Issuer,// builder.Configuration["JwtSettings:Issuer"],
              ValidAudience = jwtSettings.Audience,// builder.Configuration["JwtSettings:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(key),
              ClockSkew = TimeSpan.Zero,
          };

          // ✅ Middleware to Check Token Blacklist
          options.Events = new JwtBearerEvents
          {
              OnTokenValidated = context =>
              {
                  var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                  if (AuthController._blacklistedTokens.Contains(token))
                  {
                      context.Fail("Token is blacklisted.");
                  }
                  return Task.CompletedTask;
              }
          };
      });

builder.Services.AddAuthorization();


 


ServiceConfig.Register(builder);

builder.Services.AddEndpointsApiExplorer();   // ✅ needed for Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Beanz API", Version = "v1" });
    c.CustomSchemaIds(type => type.FullName);
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.DocInclusionPredicate((docName, apiDesc) => !string.IsNullOrEmpty(apiDesc.RelativePath));
});

// ---------- Pipeline ----------
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("Open");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Beanz API v1"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();   // ✅ enough for API controllers


// =========================================================
// Ensure auth schema exists at startup
// =========================================================
using (var scope = app.Services.CreateScope())
{
    var ensureRepo = scope.ServiceProvider.GetRequiredService<IAuthEnsureRepository>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Ensuring auth schema on startup...");

        var steps = new (string Name, Func<Task<GeneralResponseDTO>> Run)[]
        {
            ("Schema",                  () => ensureRepo.EnsureAuthSchemaAsync()),
            ("AudSchema",               () => ensureRepo.EnsureAudSchemaAsync()),
            ("AuditLog",                () => ensureRepo.EnsureAuditLogsTableAsync()),
            ("Users",                   () => ensureRepo.EnsureUsersTableAsync()),
            ("Roles",                   () => ensureRepo.EnsureRolesTableAsync()),
            ("UserRoles",               () => ensureRepo.EnsureUserRolesTableAsync()),
            ("UserSessions",            () => ensureRepo.EnsureUserSessionsTableAsync()),
            ("UserTokens",              () => ensureRepo.EnsureUserTokensTableAsync()),
            ("LoginAttempts",           () => ensureRepo.EnsureLoginAttemptsTableAsync()),
            ("EmailVerificationTokens", () => ensureRepo.EnsureEmailVerificationTokensTableAsync()), 
            ("ExternalLogins",          () => ensureRepo.EnsureExternalLoginsTableAsync()),
            ("UserMFA",                 () => ensureRepo.EnsureUserMFATableAsync()),
            ("MFAOTPs",                 () => ensureRepo.EnsureMFAOTPsTableAsync()),
            ("Companies",               () => ensureRepo.EnsureCompaniesTableAsync()),
            ("UserCompanies",           () => ensureRepo.EnsureUserCompaniesTableAsync()),
            ("DefaultCompany",          () => ensureRepo.SeedDefaultCompanyAsync()),
            ("EndPointTable",           () => ensureRepo.EnsureSystemEndpointsTableAsync()),
            ("EnsureUserTrigger",       () => ensureRepo.EnsureUsersEmailChangedTriggerAsync()),

        };

        foreach (var step in steps)
        {
            var result = await step.Run();
            if (!result.Success)
            {
                logger.LogError("Auth ensure failed at step {Step}: {Message}", step.Name, result.Message);
                throw new InvalidOperationException(
                    $"Auth schema initialization failed at '{step.Name}': {result.Message}");
            }
            logger.LogInformation("Auth ensure OK: {Step}", step.Name);
        }

        logger.LogInformation("Auth schema is ready.");
    }
    catch (Exception ex)
    {
        logger.LogCritical(ex, "Fatal: could not ensure auth schema on startup.");
        throw; // Fail fast — don't start the app with a broken schema.
    }
} 
app.Run();
