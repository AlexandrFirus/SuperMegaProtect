namespace SuperProtector.Interfaces
{
    public interface IFileWatcher
    {
        public event Action<string>? FileAdded;
    }
}