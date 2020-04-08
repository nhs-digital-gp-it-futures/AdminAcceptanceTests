using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            using var client = new HttpClient();
            response = await client.GetAsync($"{hostUrl}:1080/email");

            var responseContent = JToken.Parse(await response.Content.ReadAsStringAsync());

            return responseContent.Select(x => new Email
            {
                PlainTextBody = x.SelectToken("text").ToString().Trim(),
                HtmlBody = x.SelectToken("html").ToString().Trim(),
                Subject = x.SelectToken("subject").ToString(),
                From = x.SelectToken("from").First().SelectToken("address").ToString(),
                To = x.SelectToken("to").First().SelectToken("address").ToString(),
            });
        }

        public static async Task ClearAllEmailsAsync(string hostUrl)
        {
            using var client = new HttpClient();
            await client.DeleteAsync(new Uri($"{hostUrl}:1080/email/all"));
        }
    }
}
