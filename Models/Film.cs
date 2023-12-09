using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("film")]
    public class Film
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("genre")]
        public string Genre { get; set; }
    }
}
