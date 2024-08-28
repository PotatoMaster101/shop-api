using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Api;
using Shop.Api.Authorization;
using Shop.Api.Extensions;
using Shop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("DataConnection");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<IShopDbContext, ShopDbContext>(o => o.UseNpgsql(dbConnection));
builder.Services.AddDbContext<IAuthenticationDbContext, AuthenticationDbContext>(o => o.UseNpgsql(dbConnection));
builder.Services.AddMediator(x =>
{
    x.Namespace = "Shop";
    x.ServiceLifetime = ServiceLifetime.Scoped;
});

// auth
var apiKey = builder.Configuration["ApiKey"]!;      // DANGER: in real app you would put API key into ENV variable or vault
builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();
builder.Services.AddScoped<IAuthorizationHandler, CanEditProductHandler>();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationDbContext>();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Constants.ApiKeyPolicy, x => x.AddRequirements(new ApiKeyRequirement(apiKey)))
    .AddPolicy(Constants.CanEditPolicy, x => x.AddRequirements(new CanEditProductRequirement()));

var app = builder.Build();
await app.ApplyMigrations<AuthenticationDbContext>();
await app.ApplyMigrations<ShopDbContext>();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGroup("/api/identity").MapIdentityApi<IdentityUser>().WithTags("Identity");
app.Run();
