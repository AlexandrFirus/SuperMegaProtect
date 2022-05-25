using HtmlAgilityPack;

namespace SuperProtector.Extensions
{
    public static class HtmlDocExtensions
    {
        public static void FixDangerousHrefs(this HtmlDocument document)
        {
            var hrefs = document.DocumentNode.Descendants("a");
            FixHrefs(hrefs);
        }

        private static void FixHrefs(IEnumerable<HtmlNode> hrefs)
        {
            foreach (var node in hrefs)
            {
                if (!node.Attributes["href"].Value.Equals(node.InnerHtml, StringComparison.OrdinalIgnoreCase))
                    node.Attributes["href"].Value = node.InnerHtml;
            }
        }
    }
}
