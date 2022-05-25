using SuperProtector.Interfaces;

namespace SuperProtector.Abstract
{
    public abstract class FileWatcher : IFileWatcher
    {
        private FileSystemWatcher _systemWatcher;
        protected abstract string Filter { get; }

        public event Action<string>? FileAdded;

        protected FileWatcher(string sourcePath)
        {
            _systemWatcher = new FileSystemWatcher(sourcePath, Filter);
            _systemWatcher.IncludeSubdirectories = false;
            _systemWatcher.EnableRaisingEvents = true;
            _systemWatcher.Created += FileCreated;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            FileAdded?.Invoke(e.FullPath);
        }
    }
}
