namespace UI.Blazor.Configuration;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder builder)
    {
        //Blazor Configuration
        public WebApplicationBuilder AddBlazorConfig()
        {
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            return builder;
        }
    }
}