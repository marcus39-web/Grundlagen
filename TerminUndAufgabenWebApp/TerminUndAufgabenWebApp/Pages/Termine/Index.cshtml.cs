using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public class IndexModel : PageModel
    {
        public List<TerminMitKategorie> TermineListe { get; set; } = new();

        public void OnGet()
        {
            var kategorien = KategorienDataStore.Load();
            var termine = TermineDataStore.Load();

            TermineListe = termine.Select(t => new TerminMitKategorie
            {
                Id = t.Id,
                Titel = t.Titel,
                Starttermin = t.Starttermin,
                DauerInMinuten = t.DauerInMinuten,
                Ort = t.Ort,
                Kontaktperson = t.Kontaktperson,
                Beschreibung = t.Beschreibung,
                Farbcode = t.Farbcode,
                KategorieTitel = kategorien.FirstOrDefault(k => k.Id == t.KategorieId)?.Titel ?? ""
            }).ToList();
        }

        public class TerminMitKategorie
        {
            public int Id { get; set; }
            public string Titel { get; set; } = string.Empty;
            public DateTime Starttermin { get; set; }
            public int DauerInMinuten { get; set; }
            public string Ort { get; set; } = string.Empty;
            public string Kontaktperson { get; set; } = string.Empty;
            public string Beschreibung { get; set; } = string.Empty;
            public string Farbcode { get; set; } = "#28a745";
            public string KategorieTitel { get; set; } = string.Empty;
        }
    }
}
