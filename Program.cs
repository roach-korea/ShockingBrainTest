using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.WebHost.UseKestrel();
builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(80);
    options.ListenAnyIP(443, listenOptions => {
        listenOptions.UseHttps("Certificates/brain-test.site.pfx", "roach12#");
    });
});

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources"))
});

app.Use(async (context, next) => {
    var ip = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
    var url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";

    Console.WriteLine($"Connected From: {ip}, Requested URL: {url}");
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapFallback(async context => {
    context.Response.Redirect("/Home/Index", permanent: false);
});

app.UseHsts();

app.Run();
