using core10_swapi.Constants;
using System.Text;

namespace core10_swapi.Helper
{
    public class APIHelper
    {
        public APIHelper()
        {

        }
        static HttpClient _httpclient;
        static bool _initialized = false;
        private static readonly ILogger<APIHelper> _logger = new LoggerFactory().CreateLogger<APIHelper>();

        static readonly object PadLock = new object();

        public async Task<T> DataRequest<T>(string httpType, Dictionary<string,string> headers, string url, string data)
        {
            T response = default(T);
            _logger.LogDebug("Start [APIHelper] DataRequest");
            _logger.LogDebug(string.Format("Start [APIHelper] DataRequest() http Type: {0}, url: {1}", httpType, url));
            try
            {
                InitializeHttpClient();
                bool isPostRequest = httpType == CommonConstants.HTTP_POST;
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var reqMessage = new HttpRequestMessage(isPostRequest ? HttpMethod.Post : HttpMethod.Get, url);

                if (headers != null && headers.Count > 0)
                {
                    foreach(var header in headers)
                    {
                        reqMessage.Headers.Add(header.Key, header.Value);
                    }
                }
                var content = new StringContent(data, Encoding.UTF8, CommonConstants.APPLICATION_CONTENT_JSON);
                reqMessage.Content = content;
                HttpResponseMessage apiResponse = isPostRequest ? await _httpclient.SendAsync(reqMessage) : await _httpclient.GetAsync(url);
                if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                {
                    string results = apiResponse.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(results))
                    {
                        response = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(results);
                    }
                }
                if(response != null)
                {
                    _logger.LogDebug($"API Response {Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
                }


            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[API Helper] Exception" + ex.Message);
                throw ex;
            }
            return response;
        }

        private void InitializeHttpClient()
        {   if (_initialized) return;
        lock (PadLock) 
            {
                if (_initialized) return;
                _httpclient = new HttpClient();
                _initialized = true;
                _logger.LogDebug("[APIHelper] InitializeHttpClient");
            }  
        }
    
    }
}
