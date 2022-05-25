namespace SuperProtector.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        void Exception(Exception ex);
    }
}
