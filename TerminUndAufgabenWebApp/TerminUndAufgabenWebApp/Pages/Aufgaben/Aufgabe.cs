using System.ComponentModel.DataAnnotations;

namespace TerminUndAufgabenWeppApp.Pages.Aufgaben
{
    public class Aufgabe
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public string Farbcode { get; set; } = "#ffffff";
        public DateTime? ZuErledigenVon { get; set; }
        public DateTime? ZuErledigenBis { get; set; }
        public string Status { get; set; } = "offen";
        public int KategorieId { get; set; }
    }
}
