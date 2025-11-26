namespace API.P.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        // Nombre de la película
        public string Name { get; set; } = null!;


        //Duracion en minutos
        public int Duration { get; set; }
        // Clasificación (ej: "PG13", "R", etc.)
        public string Clasification { get; set; } = null!;

        //Opcionales

        public string? Director { get; set; }

        public string? Studio { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public DateTime? UpdatedDate { get; internal set; }
    }
}
