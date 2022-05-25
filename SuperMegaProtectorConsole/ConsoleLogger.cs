
using SuperProtector.Interfaces;

namespace SuperMegaProtectorConsole
{
    public class ConsoleLogger : ILogger
    {
        public void Exception(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
