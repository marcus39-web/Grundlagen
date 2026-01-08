using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class IndexModel : PageModel
    {
        public List<Aufgabe> AufgabenListe { get; set; } = new();

        public void OnGet()
        {
            AufgabenListe = AufgabeDataStore.Load();
        }
    }
}
