using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Kategorien
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Kategorie Kategorie { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var kategorien = KategorienDataStore.Load();
            Kategorie.Id = kategorien.Any() ? kategorien.Max(k => k.Id) + 1 : 1;
            kategorien.Add(Kategorie);
            KategorienDataStore.Save(kategorien);

            return RedirectToPage("Index");
        }
    }
}