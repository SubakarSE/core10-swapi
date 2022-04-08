namespace core10_swapi.Models
{
    public class Film
    {
        public string title { get; set; }
        public int episode_id { get; set; }

        public List<string> films { get; set; }
    }
}
