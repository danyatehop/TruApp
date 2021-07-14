using SQLite;

namespace TruApp
{
    [Table("songs")]
    public class SongDB
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string title { get; set; }

        public string word { get; set; }

        public string type { get; set; }
    }
}
