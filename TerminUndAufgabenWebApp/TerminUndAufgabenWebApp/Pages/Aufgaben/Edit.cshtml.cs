using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Aufgabe Aufgabe { get; set; }

        public List<string> Kategorien { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var aufgaben = AufgabeDataStore.Load();
            Aufgabe = aufgaben.FirstOrDefault(a => a.Id == id) ?? new Aufgabe();

            // Fallback für alte Datensätze:
            if (string.IsNullOrEmpty(Aufgabe.Status))
                Aufgabe.Status = "offen";
            if (Aufgabe.KategorieId == 0)
            {
                // Hier ggf. Standardwert setzen, falls benötigt
            }
            // Entfernt: else Aufgabe.KategorieId = ""; // CS0029-Fix: KategorieId ist int, kein string

            Kategorien = aufgaben
                .Select(a => a.KategorieId.ToString())
                .Where(k => !string.IsNullOrWhiteSpace(k))
                .Distinct()
                .OrderBy(k => k)
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var aufgaben = AufgabeDataStore.Load();
            var index = aufgaben.FindIndex(a => a.Id == Aufgabe.Id);
            if (index >= 0)
            {
                aufgaben[index] = Aufgabe;
                AufgabeDataStore.Save(aufgaben);
            }
            return RedirectToPage("Index");
        }

    }
}