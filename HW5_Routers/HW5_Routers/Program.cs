using System.Text;
using System.Text.RegularExpressions;

namespace HW5_Routers
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Too few arguments. Should be passed 2, actual number is {0}.", args.Length);
                return 1;
            } 

            var pathInput = "/Users/annnikolaeff/MyFolder/HWSecondTerm/HW5_Routers/HW5_Routers/Scheme.txt";
            string[] lines;
            try
            {
                lines = File.ReadAllLines(pathInput);
            }
            catch (FileNotFoundException e1)
            {
                throw new FileNotFoundException();
            }
            catch (ArgumentNullException e2)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentException e3)
            {
                throw new ArgumentException();
            }

            Graph graph;
            try
            {
                graph = FileHandler.BuildGraphFromData(lines);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("incorrect data format");
                throw new ArgumentException("incorrect data format");
            }

            var result = graph.PrintMaxSpanningTree();
            if (result == null)
            {
                return 1;
            }

            var pathOutput = args[1];

            FileHandler.WriteDataToFile(result, pathOutput);

            return 0;
        }
    }
}