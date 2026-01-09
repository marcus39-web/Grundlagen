using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public static class AufgabeDataStore
    {
        private static readonly string FilePath = "App_Data/aufgaben.json";

        public static List<Aufgabe> Load()
        {
            if (!File.Exists(FilePath))
                return new List<Aufgabe>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Aufgabe>>(json) ?? new List<Aufgabe>();
        }

        public static void Save(List<Aufgabe> aufgaben)
        {
            var json = JsonSerializer.Serialize(aufgaben, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, json);
        }
    }
}