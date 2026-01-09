using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Aufgabe Aufgabe { get; set; } = new();

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