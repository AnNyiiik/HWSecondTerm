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

            var pathInput = args[0];
            Graph graph;
            try
            {
                graph = FileHandler.BuildGraphFromData(pathInput);
            }
            catch (ArgumentException e1)
            {
                throw new ArgumentException("incorrect path or data format in file");
            }
            catch (FileNotFoundException e2)
            {
                throw new FileNotFoundException();
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