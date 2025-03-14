using Elsa.EntityFrameworkCore.Extensions;
using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.EntityFrameworkCore.Modules.Runtime;
using Elsa.Extensions;
using ElsaServer.Config;
using ElsaServer.Context;
using ElsaServer.CustomActivity;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 
builder.WebHost.UseStaticWebAssets();

var services = builder.Services;
var configuration = builder.Configuration;
services.AddScoped<CreateIdeaActivity>();
services
    .AddElsa(elsa => elsa
        .UseIdentity(identity =>
        {
            identity.TokenOptions = options => options.SigningKey = "large-signing-key-for-signing-JWT-tokens";
            identity.UseAdminUserProvider();
        })
        .UseDefaultAuthentication()
        .UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef =>
            ef.UseMySql("Server=elsa-database;Port=3306;Database=elsa_database;Uid=elsa_user;Pwd=elsa_pass;")))
        .UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore())
        .UseScheduling()
        .UseJavaScript()
        .UseLiquid()
        .UseCSharp()
        .UseHttp(http => http.ConfigureHttpOptions = options => configuration.GetSection("Http").Bind(options))
        .UseWorkflowsApi()
        .UseRealTimeWorkflows()
        .AddActivitiesFrom<Program>()
        .AddWorkflowsFrom<Program>()
    );

services.AddCors(cors => cors.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("*")));
services.AddRazorPages(options => options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));
services.AddAutoMapper(typeof(MappingProfile));

services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// app.UseFastEndpoints();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseRouting();
app.UseCors();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseWorkflowsApi();
app.UseWorkflows();
app.UseWorkflowsSignalRHubs();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Run();