using SuperProtector.Abstract;

namespace SuperProtector.Html
{
    public class HtmlFileWatcher : FileWatcher
    {
        protected override string Filter => "*.html";

        public HtmlFileWatcher(string sourcePath) : base(sourcePath)
        {
        }
    }
}
