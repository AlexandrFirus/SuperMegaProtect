using HtmlAgilityPack;
using SuperProtector.Interfaces;

namespace SuperProtector.Html
{
    public class HtmlDocLoader : IFileLoader<HtmlDocument>
    {
        public HtmlDocument Load(string path)
        {
            var htmldoc = new HtmlDocument();
            using var fs = new FileStream(path, FileMode.Open);
            htmldoc.Load(fs);
            return htmldoc;
        }

        public void Save(HtmlDocument htmldoc, string path)
        {
            using var fs = new FileStream(path, FileMode.Create);
            htmldoc.Save(fs);
        }
    }
}
