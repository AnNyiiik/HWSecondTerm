using LZW;

Console.WriteLine("Enter an absolute path and the key:");
string[] arguments = Environment.GetCommandLineArgs();
if (arguments.Length <= 1)
{
    Console.WriteLine("There is no path & key");
    return;
} 
if (arguments.Length <= 2)
{
    Console.WriteLine("There is no path or key");
    return;
}
if (String.Compare(arguments[2], "-u") == 0)
{
    var dearchivator = new Dearchivator();
    var isCorrect = dearchivator.UnzipFile(arguments[1]);
    if (!isCorrect)
    {
        Console.WriteLine("Incorrect path");
    }
    return;
} 
if (String.Compare(arguments[2], "-c") == 0)
{
    var archivator = new Archiver();
    var isCorrect = archivator.ArchiveFile(arguments[1]);
    if (!isCorrect)
    {
        Console.WriteLine("Incorrect path");
    }
    return;
} 
Console.WriteLine("There is no such key");