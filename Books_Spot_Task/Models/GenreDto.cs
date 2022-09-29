using Books_Spot_Task.Entities;

namespace Books_Spot_Task.Models
{
    public class GenreDto
    {
        public string GenreName { get; set; }

        public GenreDto(GenreEntity genreEntity)
        {
            GenreName = genreEntity.GenreName;
        }
    }
}
