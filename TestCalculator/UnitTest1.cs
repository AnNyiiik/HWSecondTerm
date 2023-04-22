using System.Runtime.Versioning;
using Calculator;

namespace TestCalculator;
public class Tests
{

    private static readonly double _delta = 0.0000001;
    private static IEnumerable<TestCaseData> DataCheckBasicCases
        => new TestCaseData[]
        {
            new TestCaseData((new string[] {"1", "+", "3", "="}, 4.0)),
            new TestCaseData((new string[] {"2", "*", "2", "="}, 4.0)),
            new TestCaseData((new string[] {"6", "/", "3", "="}, 2.0)),
            new TestCaseData((new string[] {"9", "-", "8", "=" }, 1.0)),
        };

    private static IEnumerable<TestCaseData> DataCheckZeroCases
        => new TestCaseData[]
        {
            new TestCaseData((new string[] {"0", "=", "0", "="}, 0.0)),
            new TestCaseData((new string[] {"0", "-", "0", "="}, 0.0)),
            new TestCaseData((new string[] {"0", "*", "0", "="}, 0.0)),
            new TestCaseData((new string[] {"100", "+", "0", "="}, 100.0)),
            new TestCaseData((new string[] {"100", "-", "0", "="}, 100.0)),
            new TestCaseData((new string[] {"100", "*", "0", "="}, 0.0)),
            new TestCaseData((new string[] {"0", "+", "100", "="}, 100.0)),
            new TestCaseData((new string[] {"0", "-", "100", "="}, -100.0)),
            new TestCaseData((new string[] {"0", "*", "100", "="}, 0.0)),
        };

    private static IEnumerable<TestCaseData> DataCheckZeroDivisionCases
        => new TestCaseData[]
        {
            new TestCaseData((new string[] {"0", "/", "0", "="}, "Error")),
            new TestCaseData((new string[] {"1", "/", "0", "="}, "Error"))
        };

    private static IEnumerable<TestCaseData> DataCheckMoreComplexCases
        => new TestCaseData[]
        {
            new TestCaseData((new string[] {"2", "+", "="}, 4.0)),
            new TestCaseData((new string[] {"2", "-", "="}, 0.0)),
            new TestCaseData((new string[] {"3", "*", "="}, 9.0)),
            new TestCaseData((new string[] {"2", "/", "="}, 1.0)),
            
        };

    private static IEnumerable<TestCaseData> DataCheckDoubleCases
        => new TestCaseData[]
        {
            
            new TestCaseData((new string[] {"2,1", "-", "="}, 0.0)),
            
            new TestCaseData((new string[] {"2,2", "/", "="}, 1.0)),
            
        };

    private static IEnumerable<TestCaseData> DataCheckInaccurateInputCases
        => new TestCaseData[]
        {
            new TestCaseData((new string[] {"2", ",", ",", "+", "1", "="}, 3.0)),
            new TestCaseData((new string[] {",", "3", "="}, 3.0)),
            
            new TestCaseData((new string[] {"2", ",", "="}, 2.0)),
            new TestCaseData((new string[] {"2", "+", "=", "6", "="}, 6.0)),
        };

    [TestCaseSource(nameof(DataCheckBasicCases))]
    public void TestBasicCases((string[] data, double correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        var isNumber = Int32.TryParse(calculator.Acc, out var answer);
        Assert.Multiple(() =>
        {
            Assert.That(isNumber, Is.True);
            Assert.That(Math.Abs(answer - args.correctAnswer), Is.LessThan(_delta));
        });
    }

    [TestCaseSource(nameof(DataCheckZeroCases))]
    public void TestZeroCases((string[] data, double correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        var isNumber = Int32.TryParse(calculator.Acc, out var answer);
        Assert.Multiple(() =>
        {
            Assert.That(isNumber, Is.True);
            Assert.That(Math.Abs(answer - args.correctAnswer), Is.LessThan(_delta));
        });
    }

    [TestCaseSource(nameof(DataCheckZeroDivisionCases))]
    public void TestZeroDivisionCases((string[] data, string correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        Assert.That(args.correctAnswer, Is.EqualTo(calculator.Acc));
    }

    [TestCaseSource(nameof(DataCheckMoreComplexCases))]
    public void TestMoreComplexCases((string[] data, double correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        var number = calculator.Acc;
        var isNumber = Double.TryParse(number, out var answer);
        Assert.Multiple(() =>
        {
            Assert.That(isNumber, Is.True);
            Assert.That(Math.Abs(answer - args.correctAnswer), Is.LessThan(_delta));
        });
    }

    [TestCaseSource(nameof(DataCheckDoubleCases))]
    public void TestDoubleCases((string[] data, double correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        var number = calculator.Acc;
        var isNumber = Double.TryParse(number, out var answer);
        Assert.Multiple(() =>
        {
            Assert.That(isNumber, Is.True);
            Assert.That(Math.Abs(answer - args.correctAnswer), Is.LessThan(_delta));
        });
    }

    [TestCaseSource(nameof(DataCheckInaccurateInputCases))]
    public void TestInaccurateInputCases((string[] data, double correctAnswer) args)
    {
        var calculator = new CalculationHandler();
        foreach (var character in args.data)
        {
            calculator.CalculationProcess(character);
        }
        var number = calculator.Acc;
        var isNumber = Double.TryParse(number, out var answer);
        Assert.Multiple(() =>
        {
            Assert.That(isNumber, Is.True);
            Assert.That(Math.Abs(answer - args.correctAnswer), Is.LessThan(_delta));
        });
    }
}