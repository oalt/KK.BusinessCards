using KK.BusinessCards.Apps.BlazorServer.DataProviders;
using KK.BusinessCards.Apps.BlazorServer.ViewModels;

namespace KK.BusinessCards.Apps.BlazorServer
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
      

            WebApplicationBuilder builder = WebApplication.CreateBuilder(arguments);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<IBusinessCardDataProvider, FileBusinessCardDataProvider>();
            builder.Services.AddScoped<CardListViewModel>();


            WebApplication app = builder.Build();

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
        }
    }
}

