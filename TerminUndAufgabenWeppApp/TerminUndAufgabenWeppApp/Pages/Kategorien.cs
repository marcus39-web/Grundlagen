namespace TerminUndAufgabenWeppApp.Pages
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public string? Farbcode { get; set; }
        public const string FarbeSehrWichtig = "#FF0000";
        public const string FarbeZuErledigen = "#FFFF00";
        public const string FarbeErledigt = "#00FF00";
    }
}