using AdminAcceptanceTests.Objects.Collections;

namespace AdminAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection
            {

            };
        }
        public PageCollection Pages { get; set; }
    }
}
