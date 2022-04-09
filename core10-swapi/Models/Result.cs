
using System.Net;

namespace core10_swapi.Models
{
    public class Result
    {
        public HttpStatusCode status { get; set; }
        public object result { get; set; }

        public Result(HttpStatusCode code, object rst)
        {
            status = code;
            result = rst;
        }

    }
}
