using Supabase;

namespace DiagnosticoMaquinasWasm.Services;

public class SupabaseService
{
    public Client Client { get; }

    public SupabaseService(string url, string key)
    {
        Client = new Client(url, key);
    }

    public async Task InicializarAsync()
    {
        await Client.InitializeAsync();
    }
}