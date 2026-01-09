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
        public List<Kategorie> Kategorien { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Kategorien = KategorienDataStore.Load();

            var termine = TermineDataStore.Load();
            var termin = termine.FirstOrDefault(t => t.Id == id);
            if (termin == null)
                return RedirectToPage("Index");
            Termin = termin!;
            KategorieId = Termin.KategorieId; // KategorieId für das Dropdown setzen
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Kategorien = KategorienDataStore.Load();
                return Page();
            }

            var termine = TermineDataStore.Load();
            var index = termine.FindIndex(t => t.Id == Termin.Id);
            if (index >= 0)
            {
                // Kategorie zuweisen
                var kategorien = KategorienDataStore.Load();
                Termin.KategorieId = Termin.KategorieId; // (wird durch das Formular gebunden)

                var kategorie = Kategorien.FirstOrDefault(k => k.Id == Termin.KategorieId);
                if (kategorie != null)
                    Termin.Farbcode = kategorie.Farbcode;

                termine[index] = Termin;
                TermineDataStore.Save(termine);
                return RedirectToPage("Index");
            }
            // Falls kein passender Termin gefunden wurde, zurück zur Index-Seite
            return RedirectToPage("Index");
        }
    }
}