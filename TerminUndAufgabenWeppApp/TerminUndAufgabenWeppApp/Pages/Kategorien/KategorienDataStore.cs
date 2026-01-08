using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Kategorien
{
    public static class KategorienDataStore
    {
        private static readonly string FilePath = "App_Data/kategorien.json";

        public static List<Kategorie> Load()
        {
            if (!File.Exists(FilePath))
                return new List<Kategorie>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Kategorie>>(json) ?? new List<Kategorie>();
        }

        public static void Save(List<Kategorie> kategorien)
        {
            var json = JsonSerializer.Serialize(kategorien, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            File.WriteAllText(FilePath, json);
        }
    }
}