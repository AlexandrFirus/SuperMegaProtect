using HtmlAgilityPack;
using SuperProtector.Abstract;
using SuperProtector.Extensions;
using SuperProtector.Interfaces;

namespace SuperProtector.Html
{
    public class HtmlFileProtector : FileProtector<HtmlDocument>
    {
        public HtmlFileProtector(ILogger logger, IFileLoader<HtmlDocument> loader, FileWatcher watcher, string targetDirectory)
            : base(logger, loader, watcher, targetDirectory)
        {
        }

        protected override void Protect(HtmlDocument htmlDoc)
        {
            htmlDoc.FixDangerousHrefs();
        }
    }
}
