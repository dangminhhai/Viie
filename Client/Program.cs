using BaseLibrary.Entities;
using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
                                                                                                                                            

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7294/");
}).AddHttpMessageHandler<CustomHttpHandler>(); ;

// license Syncfusion
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("xxxxxxxx");

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddScoped<ILocaleStringResourceService, LocaleStringResourceService>();

//Location / Business Unit / Department / JobPosition
builder.Services.AddScoped<IGenericServiceInterface<Location>, GenericServiceImplementation<Location>>();
builder.Services.AddScoped<IGenericServiceInterface<BusinessUnit>, GenericServiceImplementation<BusinessUnit>>();
builder.Services.AddScoped<IGenericServiceInterface<Department>, GenericServiceImplementation<Department>>();
builder.Services.AddScoped<IGenericServiceInterface<JobPosition>, GenericServiceImplementation<JobPosition>>();

//Country / City / Town
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImplementation<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImplementation<City>>();
builder.Services.AddScoped<IGenericServiceInterface<Town>, GenericServiceImplementation<Town>>();

builder.Services.AddScoped<IGenericServiceInterface<Overtime>, GenericServiceImplementation<Overtime>>();
builder.Services.AddScoped<IGenericServiceInterface<OvertimeType>, GenericServiceImplementation<OvertimeType>>();

builder.Services.AddScoped<IGenericServiceInterface<Vacation>, GenericServiceImplementation<Vacation>>();
builder.Services.AddScoped<IGenericServiceInterface<VacationType>, GenericServiceImplementation<VacationType>>();

builder.Services.AddScoped<IGenericServiceInterface<Sanction>, GenericServiceImplementation<Sanction>>();
builder.Services.AddScoped<IGenericServiceInterface<SanctionType>, GenericServiceImplementation<SanctionType>>();

builder.Services.AddScoped<IGenericServiceInterface<Doctor>, GenericServiceImplementation<Doctor>>();
//Employee
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImplementation<Employee>>();

builder.Services.AddScoped<AllState>();
builder.Services.AddScoped<UserProfileState>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
