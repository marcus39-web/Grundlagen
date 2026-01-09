using System;

namespace TerminUndAufgabenWeppApp.Pages
{
    public class Aufgabe
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public DateTime ZuErledigenVon { get; set; }
        public DateTime ZuErledigenBis { get; set; }
        public string Farbcode { get; set; } = "#28a745";
        public string Kategorie { get; set; } = string.Empty;
        public string Status { get; set; } = "offen";
    }
}
