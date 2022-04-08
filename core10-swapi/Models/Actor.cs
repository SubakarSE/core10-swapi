﻿namespace core10_swapi.Models
{
    public class Actor
    {
        public string name { get; set; }
        public string height { get; set; }
        public  string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<object> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
        public List<ActorVehicleDetails> vehicleInfo { get; set; }


    }
}