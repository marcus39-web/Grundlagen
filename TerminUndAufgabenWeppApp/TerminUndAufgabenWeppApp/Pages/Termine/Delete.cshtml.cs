using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Termin Termin { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var termine = TermineDataStore.Load();
            Termin = termine.FirstOrDefault(t => t.Id == id) ?? new Termin();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var termine = TermineDataStore.Load();
            var toRemove = termine.FirstOrDefault(t => t.Id == id);
            if (toRemove != null)
            {
                termine.Remove(toRemove);
                TermineDataStore.Save(termine);
            }
            return RedirectToPage("Index");
        }
    }
}