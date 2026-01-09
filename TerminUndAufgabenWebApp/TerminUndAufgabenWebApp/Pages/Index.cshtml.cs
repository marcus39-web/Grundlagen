using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TerminUndAufgabenWeppApp.Pages.Aufgaben; // Nur diesen Namespace verwenden

//namespace TerminUndAufgabenWeppApp.Pages.Aufgaben // Namespace angepasst
//{
//    public class IndexModel : PageModel
//    {
//        public List<Aufgabe> AufgabeListe { get; set; } = new();

//        public void OnGet() => AufgabeListe = AufgabeDataStore.Load();
//    }
//}

namespace TerminUndAufgabenWeppApp.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
