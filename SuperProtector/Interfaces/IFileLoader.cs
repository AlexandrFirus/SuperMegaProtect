namespace SuperProtector.Interfaces
{
    public interface IFileLoader<T> where T : class
    {
        T Load(string path);
        void Save(T document, string path);
    }
}
