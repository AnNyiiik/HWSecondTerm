using System.Text;
using System.Text.RegularExpressions;

namespace HW5_Routers;

public static class FileHandler
{
    public static Graph BuildGraphFromData(string[]? lines)
    {
        if (lines == null || lines.Length == 0)
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
                throw new ArgumentException();
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
                throw new ArgumentException();
            }

            var nodeSecond = 0; // иначе ругается, не могу не инициализировать, знаю что бесполезно :)
            for (var i = 1; i < data.Length; ++i)
            {
                if (i % 2 == 1)
                {
                    isNumber = Int32.TryParse(data[i], out nodeSecond);
                    if (!isNumber)
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    isNumber = Int32.TryParse(data[i], out var weight);
                    if (!isNumber)
                    {
                        throw new ArgumentException();
                    }

                    graph.AddEdge(nodeFirst, nodeSecond, weight);
                }
            }
        }

        return graph;
    }

    public static void WriteDataToFile(string? data, string? path)
    {
        if (String.IsNullOrEmpty(path) || data == null)
        {
            throw new ArgumentException();
        }
        
        try
        {
            using (var fileStreamWriter = new StreamWriter(path))
            {
                fileStreamWriter.Write(data);
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
    }
}