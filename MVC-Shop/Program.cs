using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.Cards.Services;
using App_Domain_Core.Bank.contract;
using Microsoft.AspNetCore.Authentication;
using quiz.Contracts;
using quiz.reposetories;
using quiz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<BankDBContext>();
builder.Services.AddScoped<ICardReposetory, CardReposetory>();
builder.Services.AddScoped<ITransactionReposetory,TransactionReposetory>();
builder.Services.AddScoped<Iauthentication, authentication>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IAuthnticationAppService, AuthnticationAppService>();
builder.Services.AddScoped<ITransferAppService, TransferAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
