using System.ComponentModel.DataAnnotations;

namespace ServerTrainingTool.Domain
{
    public class Tabella_Corsi
    {
        public long Id { get; set; }
        public string? Docente { get; set; }
        public bool Effettuato { get; set; }
    }
}
