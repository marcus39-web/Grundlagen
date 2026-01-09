using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TerminUndAufgabenWeppApp.Pages.Kategorien;


namespace TerminUndAufgabenWeppApp.Pages.Kategorien
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Kategorie Kategorie { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var kategorien = KategorienDataStore.Load();
            Kategorie = kategorien.FirstOrDefault(k => k.Id == id) ?? new Kategorie();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var kategorien = KategorienDataStore.Load();
            var index = kategorien.FindIndex(k => k.Id == Kategorie.Id);
            if (index >= 0)
            {
                kategorien[index] = Kategorie;
                KategorienDataStore.Save(kategorien);
            }
            return RedirectToPage("Index");
        }
    }
}

