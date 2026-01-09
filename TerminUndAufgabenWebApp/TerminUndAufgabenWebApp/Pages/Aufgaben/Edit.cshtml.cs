using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Aufgabe Aufgabe { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var aufgaben = AufgabeDataStore.Load();
            Aufgabe = aufgaben.FirstOrDefault(a => a.Id == id) ?? new Aufgabe();
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