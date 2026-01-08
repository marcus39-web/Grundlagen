using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Kategorien
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Kategorie Kategorie { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var kategorien = KategorienDataStore.Load();
            Kategorie = kategorien.FirstOrDefault(k => k.Id == id) ?? new Kategorie();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var kategorien = KategorienDataStore.Load();
            var toRemove = kategorien.FirstOrDefault(k => k.Id == id);
            if (toRemove != null)
            {
                kategorien.Remove(toRemove);
                KategorienDataStore.Save(kategorien);
            }
            return RedirectToPage("Index");
        }
    }
}