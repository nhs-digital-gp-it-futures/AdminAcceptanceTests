namespace AdminAcceptanceTests.Actions.Utils
{
    using System.Text.RegularExpressions;

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
            Regex r = new("<a href=\"(?<url>.*)\"");
            var match = r.Match(HtmlBody);
            return match.Groups["url"].Value;
        }
    }
}
