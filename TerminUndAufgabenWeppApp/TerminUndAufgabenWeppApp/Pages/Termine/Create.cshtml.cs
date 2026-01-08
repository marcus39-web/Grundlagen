using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Termin Termin { get; set; } = new();

        [BindProperty]
        public int KategorieId { get; set; }

        public List<SelectListItem> KategorienListe { get; set; } = new();


  


        public void OnGet()
        {
            var kategorien = KategorienDataStore.Load();
            KategorienListe = kategorien
                .Select(k => new SelectListItem { Value = k.Id.ToString(), Text = k.Titel })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var termine = TermineDataStore.Load();
            Termin.Id = termine.Any() ? termine.Max(t => t.Id) + 1 : 1;

            var kategorien = KategorienDataStore.Load();
            Termin.Kategorie = kategorien.FirstOrDefault(k => k.Id == KategorieId);

            termine.Add(Termin);
            TermineDataStore.Save(termine);

            return RedirectToPage("Index");
        }
    }
}