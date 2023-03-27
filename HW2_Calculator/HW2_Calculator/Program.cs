using HW2_Calculator;

if (!Test.TestStackImplementation())
{
    Console.WriteLine("Test has been failed");
    return;
}
Console.WriteLine("To choose a stack based on array press 1\nTo choose a stack based on list press 2\n");
var isCorrect = Int32.TryParse(Console.ReadLine(), out var option);
if (!isCorrect)
{
    Console.WriteLine("Not a number");
    return;
}

if (option > 2 || option < 1)
{
    Console.WriteLine("Not an option");
    return;
}
StackCalculator calculator;
if (option == 1)
{
    var stackArray = new StackBasedOnArray();
    calculator = new StackCalculator(stackArray);
}
else
{
    var stackList = new StackBasedOnList();
    calculator = new StackCalculator(stackList);
}
Console.WriteLine("enter the expression to calculate:\n");
var expression = Console.ReadLine();
var result = (expression != null) ? calculator.Calculate(expression) : new Tuple<bool, double?>(false, 0);
if (result.Item1 == false)
{
    Console.WriteLine("An expression is incorrect");
    return;
}
Console.WriteLine("A result is {0}", result.Item2);