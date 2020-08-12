using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdminAcceptanceTests.Actions.Utils
{
    public sealed class Email
    {
        public string Id { get; set; }
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string PlainTextBody { get; set; }

        public string HtmlBody { get; set; }

        public string ExtractUrlFromHtmlBody()
        {
            Regex r = new Regex("<a href=\"(?<url>.*)\"");
            Match match = r.Match(this.HtmlBody);
            return match.Groups["url"].Value;
        }
    }
}
