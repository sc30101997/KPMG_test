
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Net;
using System.Text;



    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request");

        String name = req.GetQueryNameValuePairs();
        .FirstOrDefault(q => string.Compare(q.Key, “name”, true) == 0)
        .value;

        dynamic data = await req.Content.ReadAsAsync<object>();

        name = name ?? data?.name;

        Website site = new Website();
        site.Name = "TestSite";
        site.Url = "https://TheFlyingNaverick.com";
        site.Author = "Sourabh";
        site.Country = "India";

        return name == null
         ? new HttpResponseMessage(HttpStatusCode.BadRequest)
         {
             Content = new StringContent(JsonConvert.SerializeObject("please pass a name in the request body"), Encoding.UTF8, "application/json")
         }
         : new HttpResponseltessage(HttpStatusCode.OK)
         {
             Content = new StringContent(JsonConvert.SerializeObject(site, Formatting.Indented), Encoding.UTF8, “application / json")
    
         };
    }

    public static class Website
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public string Country { get; set; }
    }
