using LZW;

public static class Program
{
    public static void Main(string[] args)
    {
        var archiver = new Archiver();
        archiver.ArchiveFile("/Users/annnikolaeff/MyFolder/HWSecondTerm/LZW/LZW/NewFile1.txt1");
        var dearchiver = new Dearchivator();
        dearchiver.UnzipFile("/Users/annnikolaeff/MyFolder/HWSecondTerm/LZW/LZW/NewFile1.zipped");
        /* var arguments = Environment.GetCommandLineArgs();
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
        if (String.Compare(arguments[1], "-u") == 0)
        {
            var dearchivator = new Dearchivator();
            var isCorrect = dearchivator.UnzipFile(arguments[2]);
            if (!isCorrect)
            {
                Console.WriteLine("Incorrect path");
            }
            return;
        } 
        if (String.Compare(arguments[1], "-c") == 0)
        {
            var archivator = new Archiver();
            var isCorrect = archivator.ArchiveFile(arguments[2]);
            if (!isCorrect)
            {
                Console.WriteLine("Incorrect path");
            }
            return;
        } 
        Console.WriteLine("There is no such key"); */
    } 
}
