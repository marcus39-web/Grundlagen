using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Termin Termin { get; set; } = new();
        [BindProperty]
        [Display(Name = "Kategorie")]
        public int KategorieId { get; set; }
        public List<SelectListItem> KategorienListe { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            // Kategorien für das Dropdown laden
            var kategorien = KategorienDataStore.Load();
            KategorienListe = kategorien
                .Select(k => new SelectListItem { Value = k.Id.ToString(), Text = k.Titel })
                .ToList();

            var termine = TermineDataStore.Load();
            var termin = termine.FirstOrDefault(t => t.Id == id);
            if (termin == null)
                return RedirectToPage("Index");
            Termin = termin!;
            KategorieId = termin.Kategorie?.Id ?? 0; // KategorieId für das Dropdown setzen
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // KategorienListe erneut befüllen, falls Validierung fehlschlägt
                var kategorien = KategorienDataStore.Load();
                KategorienListe = kategorien
                    .Select(k => new SelectListItem { Value = k.Id.ToString(), Text = k.Titel })
                    .ToList();
                return Page();
            }

            var termine = TermineDataStore.Load();
            var index = termine.FindIndex(t => t.Id == Termin.Id);
            if (index >= 0)
            {
                // Kategorie zuweisen
                var kategorien = KategorienDataStore.Load();
                Termin.Kategorie = kategorien.FirstOrDefault(k => k.Id == KategorieId);

                termine[index] = Termin;
                TermineDataStore.Save(termine);
                return RedirectToPage("Index");
            }
            // Falls kein passender Termin gefunden wurde, zurück zur Index-Seite
            return RedirectToPage("Index");
        }
    }
}