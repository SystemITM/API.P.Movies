namespace API.P.Movies.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        public string Name { get; set; } = null!;

        public int Duration { get; set; }

        public string Clasification { get; set; } = null!;

        public string? Director { get; set; }

        public string? Studio { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
