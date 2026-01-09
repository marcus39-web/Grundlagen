using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerminUndAufgabenWeppApp.Pages.Kategorien; // Importiere den Namespace für Kategorien

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Aufgabe Aufgabe { get; set; } = new();

        public List<Kategorie> Kategorien { get; set; } = new();

        public void OnGet()
        {
            // Hier solltest du die Kategorien aus der zentralen Quelle laden!
            Kategorien = KategorienDataStore.Load();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var aufgaben = AufgabeDataStore.Load();
            Aufgabe.Id = aufgaben.Any() ? aufgaben.Max(a => a.Id) + 1 : 1;
            aufgaben.Add(Aufgabe);
            AufgabeDataStore.Save(aufgaben);

            return RedirectToPage("Index");
        }
    }
}