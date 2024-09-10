using HealthcareManager.Components;
using HealthcareManager.Components.Account;
using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Repositories;
using HealthcareManager.Repositories.AppointmentsRepository;
using HealthcareManager.Repositories.MedicationsRepository;
using HealthcareManager.Repositories.ProviderRepository;
using HealthcareManager.Utility;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;



try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
    {
        ApplicationName = typeof(Program).Assembly.FullName,
        ContentRootPath = Directory.GetCurrentDirectory(),
#if DEBUG
        EnvironmentName = Environments.Development,
#else
        EnvironmentName = Environments.Production,
#endif
        WebRootPath = Path.Combine(Environment.CurrentDirectory, "Content")
    });

    // Add services to the container.
    //builder.Services.AddScoped<SQLMedicalRecordsRepository>();
    builder.Services.AddTelerikBlazor();
    builder.Services.AddScoped<TelerikNotification>();
    builder.Services.AddScoped<ProviderSQLRepositoryActions>();
    builder.Services.AddScoped<AppointmentRepository>();
    builder.Services.AddScoped<MedicationRepository>();
    builder.Services.AddScoped<MedicalRecordsRepository>();
    builder.Services.AddSignalR();

    builder.Services.AddScoped<NotificationUtility>();
    builder.Services.AddSingleton<AppState>();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<IdentityUserAccessor>();
    builder.Services.AddScoped<IdentityRedirectManager>();
    builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();


    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
        .AddIdentityCookies();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentity<I, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
    builder.Services.AddScoped<JsInteropService>();
    builder.Services.AddSingleton<AppEventHandler>();

    builder.Logging.SetMinimumLevel(LogLevel.Information);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(HealthcareManager.Client._Imports).Assembly);

    // Add additional endpoints required by the Identity /Account Razor components.
    app.MapAdditionalIdentityEndpoints();

    app.Run();
}
catch (Exception ex)
{
    throw new NotImplementedException(ex.Message);
}
finally
{
    LoggerManager.Shutdown();
}
