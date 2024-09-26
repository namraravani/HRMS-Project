using HRMS.POC.Project.Web.API.Controllers;
using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Services;
using HRMS_POC_Project.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure database settings
builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("DatabaseConfig"));
builder.Services.AddDbContext<HrmsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HrmsDbContext>()
    .AddDefaultTokenProviders();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

// Register services
builder.Services.AddScoped<IOrganizationService, OrganizationService>(); 
builder.Services.AddScoped<IUserService, UserService>(
    provider =>
{
    var userRepository = provider.GetRequiredService<IUserRepository>();
    var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
    var jwtSecret = builder.Configuration["JWT:Secret"];
    var organizationService = provider.GetRequiredService<IOrganizationService>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
    return new UserService(userRepository, userManager, jwtSecret, organizationService, configuration, roleManager);
}
);

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UpdatePolicy", policy =>
        policy.RequireRole("Admin"));
});


builder.Services.AddControllers();
builder.Services.AddScoped<DataSeeder>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Enter a Valid Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GetOrganizationPolicy", policy =>
        policy.RequireRole("Admin","HR","Employee","SuperAdmin"));
    options.AddPolicy("CreateOrganizationPolicy", policy =>
        policy.RequireRole("SuperAdmin"));
    options.AddPolicy("UpdateOrganizationPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin"));
    options.AddPolicy("DeleteOrganizationPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin"));
    options.AddPolicy("GetUsersPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin", "HR", "Employee"));
    options.AddPolicy("UpdateUsersPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin", "HR"));
    options.AddPolicy("DeleteUsersPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin", "HR"));
    options.AddPolicy("CreateUsersPolicy", policy =>
        policy.RequireRole("Admin", "SuperAdmin", "HR"));

});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<HrmsDbContext>();

        
        await dbContext.Database.MigrateAsync();

        
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        
        var seeder = new DataSeeder(userManager, roleManager, dbContext);
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        
        Console.WriteLine($"Error during migration/seeding: {ex.Message}");
    }
}
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dataSeeder = services.GetRequiredService<DataSeeder>();
    await dataSeeder.SeedAsync(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
