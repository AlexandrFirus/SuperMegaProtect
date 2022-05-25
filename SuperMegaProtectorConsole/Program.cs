using SuperMegaProtectorConsole;
using SuperProtector.Html;
using SuperProtector.Interfaces;

var sourceDirectory = @"c:\sourcehtml\";
var targetDirectory = @"c:\targethtml\";

CheckDirectories(sourceDirectory, targetDirectory);

IFileProtector htmlPtotector = new HtmlFileProtector(new ConsoleLogger(),
    new HtmlDocLoader(),
    new HtmlFileWatcher(sourceDirectory),
    targetDirectory);

htmlPtotector.Start();

Console.WriteLine($"start watching {sourceDirectory} for html files, press ESC for exit");

while (true)
{
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape)
        return;
}

static void CheckDirectories(params string[] directories)
{
    foreach (var directory in directories)
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
}