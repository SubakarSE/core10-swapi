namespace core10_swapi.Models
{
    public class FilmData
    {
        public string title { get; set; }
        public int episode_id { get; set; }

        public List<string> species { get; set; }
    }

    public class Film
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<FilmData> results { get; set; }

    }
}
