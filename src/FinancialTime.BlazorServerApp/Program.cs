using FinancialTime.BlazorServerApp.Clients;
using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.BlazorServerApp.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FinanceConfiguration>(builder.Configuration.GetSection(FinanceConfiguration.Configuration));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<ICategoryClient, CategoryClient>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(serviceProvider.GetConfiguration<FinanceConfiguration>().TypeUrl!);
});

builder.Services.AddHttpClient<IHistoryClient, HistoryClient>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(serviceProvider.GetConfiguration<FinanceConfiguration>().OperationUrl!);
});

builder.Services.AddHttpClient<IReportClient, ReportClient>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(serviceProvider.GetConfiguration<FinanceConfiguration>().ReportUrl!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();