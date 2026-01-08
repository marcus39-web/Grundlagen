using System;

namespace TerminUndAufgabenWeppApp.Pages
{
    public class Termin
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public DateTime Starttermin { get; set; }
        public int DauerInMinuten { get; set; }
        public string Ort { get; set; } = string.Empty;
        public string Kontaktperson { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public Kategorie? Kategorie { get; set; }
        public string Farbcode { get; set; } = "#28a745"; //grün
     
    }
}
