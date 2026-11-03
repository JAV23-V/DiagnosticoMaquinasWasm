
using DiagnosticoMaquinasWasm;
using DiagnosticoMaquinasWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

var supabaseService =
    new SupabaseService(
            "https://qvqcxighrvqriphjmthm.supabase.co",
  "sb_publishable_yTawE1uKlo5neFolJ1KqSA_M7GVldw6");

await supabaseService.InicializarAsync();

builder.Services.AddSingleton(supabaseService);

builder.Services.AddSingleton<SesionService>();
builder.Services.AddScoped<ExcelService>();
await builder.Build().RunAsync();