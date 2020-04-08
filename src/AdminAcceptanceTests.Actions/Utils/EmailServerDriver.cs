using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminAcceptanceTests.Actions.Utils
{
    public sealed class EmailServerDriver
    {
        public static async Task<int> GetEmailCountAsync(string hostUrl)
        {
            var emailList = await FindAllEmailsAsync(hostUrl);
            return emailList.Count();
        }

        public static async Task<IEnumerable<Email>> FindAllEmailsAsync(string hostUrl)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using var client = NewHttpClient();
            response = await client.GetAsync(GetAllEmailsUrl(hostUrl));

            var responseContent = JToken.Parse(await response.Content.ReadAsStringAsync());

            return responseContent.Select(x => new Email
            {
                Id = x.SelectToken("id").ToString().Trim(),
                PlainTextBody = x.SelectToken("text").ToString().Trim(),
                HtmlBody = x.SelectToken("html").ToString().Trim(),
                Subject = x.SelectToken("subject").ToString(),
                From = x.SelectToken("from").First().SelectToken("address").ToString(),
                To = x.SelectToken("to").First().SelectToken("address").ToString(),
            });
        }

        public static async Task ClearAllEmailsAsync(string hostUrl)
        {
            using var client = NewHttpClient();
            await client.DeleteAsync(DeleteAllEmailsUrl(hostUrl));
        }
        public static async Task ClearEmailAsync(string hostUrl, string id)
        {
            using var client = NewHttpClient();
            await client.DeleteAsync(DeleteEmailUrl(hostUrl, id));
        }

        private static HttpClient NewHttpClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            return new HttpClient();
        }

        private static string DowngradeHttps(string value)
        {
            return value.Replace("https","http");
        }

        private static Uri GetAllEmailsUrl(string hostUrl)
        {
            return new Uri(DowngradeHttps($"{hostUrl}:1080/email"));
        }

        private static Uri DeleteAllEmailsUrl(string hostUrl)
        {
            return new Uri(DowngradeHttps($"{hostUrl}:1080/email/all"));
        }
        private static Uri DeleteEmailUrl(string hostUrl, string id)
        {
            return new Uri(DowngradeHttps($"{hostUrl}:1080/email/{id}"));
        }
    }
}
