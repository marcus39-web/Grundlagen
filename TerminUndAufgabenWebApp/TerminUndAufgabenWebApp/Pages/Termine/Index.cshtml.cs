using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TerminUndAufgabenWeppApp.Pages.Termine
{
    public class IndexModel : PageModel
    {
        public List<Termin> TermineListe { get; set; } = new();

        public void OnGet()
        {
            TermineListe = TermineDataStore.Load();
        }
    }
}
