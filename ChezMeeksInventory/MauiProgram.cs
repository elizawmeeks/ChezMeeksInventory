using Common.Infrastructure;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace ChezMeeksInventory
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(MauiProgram).Assembly);
                options.UseReduxDevTools();
            });

            builder.Services.AddScoped<Context>();
            builder.Services.AddScoped<Repository>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddMudServices();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
