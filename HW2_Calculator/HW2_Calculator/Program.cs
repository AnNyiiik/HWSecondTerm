using HW2_Calculator;

    if (!Test.TestStackImplementation())
    {
        Console.WriteLine("Test has been failed");
        return;
    }
    
    
    var obj1 = new StackBasedOnList();
    var obj2 = new StackCalculator((IStack) obj1);
    var ret = obj2.Calculate("3 12 18 + /");
    ret.ToString();