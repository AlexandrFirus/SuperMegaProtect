using SuperProtector.Interfaces;

namespace SuperProtector.Abstract
{
    public abstract class DocumentProtector<T> : IDocumentProtector where T : class
    {
        private ILogger _logger;
        private IFileLoader<T> _loader;
        private IFileWatcher _watcher;
        private string _targetDirectory;

        protected DocumentProtector(ILogger logger, IFileLoader<T> loader, IFileWatcher watcher, string targetDirectory)
        {
            _logger = logger;
            _loader = loader;
            _watcher = watcher;
            _targetDirectory = targetDirectory;
        }

        public void Start()
        {
            _watcher.FileAdded += FileAdded;
        }

        private void FileAdded(string path)
        {
            var task = new Task(() => ProcessFile(path));
            task.ConfigureAwait(false);
            task.Start();
        }

        private void ProcessFile(string path)
        {
            try
            {
                var document = _loader.Load(path);
                Protect(document);
                var targetFilePath = Path.Combine(_targetDirectory, Path.GetFileName(path));
                _loader.Save(document, targetFilePath);
            }
            catch (Exception ex)
            {
                _logger.Exception(ex);
            }
        }

        protected abstract void Protect(T document);
    }
}
