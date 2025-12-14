using System.Text.Json;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Cargando Datos de Ecuador (C#) ---");

        string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../../provincias.json");
        // Ajuste de ruta: bin/Debug/net6.0/ (3 niveles) + examples/csharp (2 niveles) = 5 niveles arriba? 
        // Mejor usar ruta relativa simple desde la ejecución del proyecto si se corre con 'dotnet run' desde la carpeta.
        // Si corremos 'dotnet run' desde examples/csharp, el CWD es examples/csharp.
        
        // Intentemos leer asumiendo ejecución desde examples/csharp
        string relativePath = "../../provincias.json";
        
        if (!File.Exists(relativePath))
        {
            Console.WriteLine($"Advertencia: No se encontró en {relativePath}, intentando búsqueda absoluta...");
            relativePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../provincias.json"));
        }

        if (File.Exists(relativePath))
        {
            try
            {
                string jsonString = File.ReadAllText(relativePath);
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    JsonElement root = doc.RootElement;
                    int count = 0;
                    foreach (JsonProperty property in root.EnumerateObject())
                    {
                        count++;
                    }
                    Console.WriteLine($"Se encontraron {count} provincias.");
                    
                    if (root.TryGetProperty("1", out JsonElement azuay))
                    {
                         Console.WriteLine("- Ejemplo: " + azuay.GetProperty("provincia").GetString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Error: No se encontró el archivo.");
        }
    }
}
