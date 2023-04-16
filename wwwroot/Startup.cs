public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure services
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure middleware

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "option",
                pattern: "/option",
                defaults: new { controller = "Home", page = "/StaticPages/Option.cshtml" });
        });
    }
}
