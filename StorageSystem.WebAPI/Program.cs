using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StorageSystem.Application;
using System.Text;
using StorageSystem.DataAccess;
using StorageSystem.Persistence.Contracts;
using StorageSystem.Persistence;
using StorageSystem.Application.Contracts.Features.Auths;
using StorageSystem.Application.Features.Auths;
using StorageSystem.Application.Features.Services;
using StorageSystem.Cache;
using Nest;
using StorageSystem.WebAPI;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using StorageSystem.WebAPI.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuration Serilog
        builder.Host.UseSerilog(LoggingExtension.ConfigureLogging);
        Log.Information("Starting project ...");

        // Configuration CORS
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials();
            });
        });

        // Elasticsearch configuration
        Log.Information("Connection to Elasticsearch");
        var url = builder.Configuration["ElasticConfiguration:url"];
        var defaultIndex = builder.Configuration["ElasticConfiguration:index"];
        var settings = new ConnectionSettings(new Uri(url)).BasicAuthentication("", "")
                .PrettyJson()
                .DisableDirectStreaming()
                .DefaultIndex(defaultIndex);

        var client = new ElasticClient(settings);

        builder.Services.AddSingleton<IElasticClient>(client);

        // Configuration Redis
        builder.Services.AddStackExchangeRedisExtension(builder.Configuration);

        // Registration Entity Framework
        builder.Services.AddPersistenceServiceRegistration(builder.Configuration);

        // Adding Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey"))),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };
        });

        builder.Services.Configure<IdentityOptions>(options =>
        {
            //Thiết lập về Password
            options.Password.RequireDigit = false; // Không bắt phải có số
            options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
            options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
            options.Password.RequireUppercase = false; // Không bắt buộc chữ in
            options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
            options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

            // Cấu hình Lockout - khóa user
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Khóa 1 phút
            options.Lockout.MaxFailedAccessAttempts = 3; // Thất bại 5 lần thì khóa
            options.Lockout.AllowedForNewUsers = true;

            // Cấu hình về User.
            options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true; // Email là duy nhất

            // Cấu hình đăng nhập.
            //options.SignIn.RequireConfirmedEmail = true; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
            options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại
        });

        // Registration Services
        builder.Services.AddApplicationServiceRegistration();

        // Registration DataAccess
        builder.Services.AddDataAccessServiceRegistration();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MigrateDatabase();

        //using (var scope = app.Services.CreateScope())
        //{
        //    var datacontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //    datacontext.Database.Migrate();
        //}

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRedisInformation();
        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);

        app.MapControllers();


        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}