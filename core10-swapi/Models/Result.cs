
using System.Net;

namespace core10_swapi.Models
{
    public class Result
    {
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
        public object result { get; set; }
    }
}
