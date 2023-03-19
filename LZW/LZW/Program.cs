using LZW;

public static class Program
{
    public static void Main(string[] args)
    {
        var arguments = Environment.GetCommandLineArgs();
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
            dearchivator.UnzipFile(arguments[2]);
            return;
        } 
        if (String.Compare(arguments[1], "-c") == 0)
        {
            var archivator = new Archiver();
            archivator.ArchiveFile(arguments[2]);
            return;
        } 
        Console.WriteLine("There is no such key"); 
    } 
}
