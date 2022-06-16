using HtmlAgilityPack;
using SuperProtector.Abstract;
using SuperProtector.Interfaces;

namespace SuperProtector.Html
{
    public class HtmlDocProtector : DocumentProtector<HtmlDocument>
    {
        public HtmlDocProtector(ILogger logger, IFileLoader<HtmlDocument> loader, IFileWatcher watcher, string targetDirectory)
            : base(logger, loader, watcher, targetDirectory)
        {
        }


        protected override void Protect(HtmlDocument htmlDoc)
        {
            var hrefs = htmlDoc.DocumentNode.Descendants("a");
            FixHrefs(hrefs);
        }

        private static void FixHrefs(IEnumerable<HtmlNode> hrefs)
        {
            foreach (var node in hrefs)
            {
                if (node.Attributes["href"]?.Value != null &&
                    IsDangerousHref(node))
                {
                    node.Attributes["href"].Value = node.InnerHtml;
                }
            }
        }

        private static bool IsDangerousHref(HtmlNode node)
        {
            return !node.Attributes["href"].Value.Equals(node.InnerHtml, StringComparison.OrdinalIgnoreCase);
        }
    }
}
