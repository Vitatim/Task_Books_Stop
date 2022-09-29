using System.ComponentModel.DataAnnotations;

namespace Books_Spot_Task.Entities
{
    public class GenreEntity
    {
        [Key]
        public string GenreName { get; set; }
    }
}
