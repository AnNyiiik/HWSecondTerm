using System.Text;
using System.Text.RegularExpressions;

namespace HW5_Routers
{
    public class Program
    {
        public static int Main(string[] args)
        {
            /* if (args.Length != 2)
            {
                Console.WriteLine("Too few arguments. Should be passed 2, actual number is {0}.", args.Length);
                return 1;
            } */

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

            var regex = new Regex(@"^(\d+):(\s(\d+)\s\((\d+)\)(,))*(\s(\d+)\s\((\d+)\))");
            var graph = new Graph();
            foreach (var line in lines)
            {
                var isMatch = regex.IsMatch(line);
                if (!isMatch)
                {
                    Console.WriteLine("incorrect data format");
                    throw new ArgumentException("incorrect data format");
                }

                var lineCopy = new StringBuilder(line);
                lineCopy.Replace(",", "");
                lineCopy.Replace("(", "");
                lineCopy.Replace(")", "");
                lineCopy.Replace(":", "");
                var data = lineCopy.ToString().Split();
                var isNumber = Int32.TryParse(data[0], out var nodeFirst);
                if (!isNumber)
                {
                    Console.WriteLine("incorrect data format");
                    throw new ArgumentException("incorrect data format");
                }

                var nodeSecond = 0; // иначе ругается, не могу не инициализировать, знаю что бесполезно :)
                for (var i = 1; i < data.Length; ++i)
                {
                    if (i % 2 == 1)
                    {
                        isNumber = Int32.TryParse(data[i], out nodeSecond);
                        if (!isNumber)
                        {
                            Console.WriteLine("incorrect data format");
                            throw new ArgumentException("incorrect data format");
                        }
                    }
                    else
                    {
                        isNumber = Int32.TryParse(data[i], out var weight);
                        if (!isNumber)
                        {
                            Console.WriteLine("incorrect data format");
                            throw new ArgumentException("incorrect data format");
                        }

                        graph.AddEdge(nodeFirst, nodeSecond, weight);
                    }
                }
            }

            var result = graph.PrintMaxSpanningTree();
            if (result == null)
            {
                return 1;
            }

            var pathOutput = args[1];

            try
            {
                using (var fileStreamWriter = new StreamWriter(pathOutput))
                {
                    fileStreamWriter.Write(result);
                }
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

            return 0;
        }
    }
}