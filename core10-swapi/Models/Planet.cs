namespace core10_swapi.Models
{
    public class Planet
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PlanetData> results { get; set; }

    }

    public class  PlanetData
    {
        public string name { get; set; }
        public string population { get; set; }

    }
}
