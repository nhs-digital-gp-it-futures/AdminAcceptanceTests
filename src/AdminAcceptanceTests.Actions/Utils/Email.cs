using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Utils
{
    public sealed class Email
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string PlainTextBody { get; set; }

        public string HtmlBody { get; set; }
    }
}
