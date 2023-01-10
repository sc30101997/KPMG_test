using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace KPMG_Test.Function
{
    public static class QRCodeDecrypt
    {
        [FunctionName("KPMG-Test")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("KPMG-Test function processed a request.");

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }

            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string clob = data?.clob;

            DecryptRequest request = new DecryptRequest();
            request.CiphertextBlob = clob;
            try
            {
                codeData codeData = codeData.fromCsv(decoded);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(codeData), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.ToString())
                };

            }
        }
    }
}
