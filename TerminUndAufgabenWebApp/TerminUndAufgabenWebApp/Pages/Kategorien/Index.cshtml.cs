using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TerminUndAufgabenWeppApp.Pages.Kategorien;

namespace TerminUndAufgabenWeppApp.Pages.Kategorien
{
    public class IndexModel : PageModel
    {
        public List<Kategorie> KategorienListe { get; set; } = new();

        public void OnGet()
        {
            KategorienListe = KategorienDataStore.Load();
        }
    }
}