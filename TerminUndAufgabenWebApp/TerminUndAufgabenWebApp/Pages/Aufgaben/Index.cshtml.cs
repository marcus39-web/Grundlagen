using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class IndexModel : PageModel
    {
        public List<AufgabeMitKategorie> AufgabenListe { get; set; } = new();

        public void OnGet()
        {
            var kategorien = KategorienDataStore.Load();
            var aufgaben = AufgabeDataStore.Load();

            AufgabenListe = aufgaben.Select(a => new AufgabeMitKategorie
            {
                Id = a.Id,
                Titel = a.Titel,
                Beschreibung = a.Beschreibung,
                Farbcode = a.Farbcode,
                Status = a.Status,
                ZuErledigenVon = a.ZuErledigenVon,
                ZuErledigenBis = a.ZuErledigenBis,
                KategorieTitel = kategorien.FirstOrDefault(k => k.Id == a.KategorieId)?.Titel ?? ""
            }).ToList();
        }

        public class AufgabeMitKategorie
        {
            public int Id { get; set; }
            public string Titel { get; set; } = string.Empty;
            public string Beschreibung { get; set; } = string.Empty;
            public string Farbcode { get; set; } = "#ffffff";
            public string Status { get; set; } = string.Empty;
            public DateTime? ZuErledigenVon { get; set; }
            public DateTime? ZuErledigenBis { get; set; }
            public string KategorieTitel { get; set; } = string.Empty;
        }
    }
}
