using HW5_Routers;

using System;

Console.WriteLine("Enter the path to file:");
var path = Console.ReadLine();
try
{
    var lines = File.ReadAllLines(path);
    foreach (var line in lines)
    {

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