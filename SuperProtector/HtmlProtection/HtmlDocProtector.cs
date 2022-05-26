using HtmlAgilityPack;
using SuperProtector.Abstract;
using SuperProtector.Extensions;
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
            htmlDoc.FixDangerousHrefs();
        }
    }
}
