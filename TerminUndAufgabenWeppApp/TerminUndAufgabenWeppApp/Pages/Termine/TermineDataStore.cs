using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public static class TermineDataStore
    {
        private static readonly string FilePath = "App_Data/termine.json";

        public static List<Termin> Load()
        {
            if (!File.Exists(FilePath))
                return new List<Termin>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Termin>>(json) ?? new List<Termin>();
        }

        public static void Save(List<Termin> termine)
        {
            var json = JsonSerializer.Serialize(termine, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, json);
        }
    }
}