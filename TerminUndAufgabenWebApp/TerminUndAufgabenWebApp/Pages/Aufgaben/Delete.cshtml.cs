using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Aufgabe Aufgabe { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var aufgaben = AufgabeDataStore.Load();
            Aufgabe = aufgaben.FirstOrDefault(a => a.Id == id) ?? new Aufgabe();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var aufgaben = AufgabeDataStore.Load();
            var toRemove = aufgaben.FirstOrDefault(a => a.Id == id);
            if (toRemove != null)
            {
                aufgaben.Remove(toRemove);
                AufgabeDataStore.Save(aufgaben);
            }
            return RedirectToPage("Index");
        }
    }
}