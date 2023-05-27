using System.Text;
using ExpressionTree;

namespace TestTree;

public class Tests
{
    [Test]
    public void TestTrueCases()
    {
        var expressions = File.ReadAllLines("../../../../BinaryExpressionTree.Tests/TestTruth.txt");
        var answers = File.ReadAllLines("../../../../BinaryExpressionTree.Tests/TestTruthAnswers.txt");
        for (var i = 0; i < expressions.Length; ++i)
        {
            var tree = new BinaryExpressionTree(expressions[i]);
            var result = tree.CountExpression();
            Double correctAnswer;
            Double.TryParse(answers[i], out correctAnswer);
            Assert.That(result, Is.EqualTo(correctAnswer));
        }
    }

    [Test]
    public void CasesWithIncorrectExpressionShouldThrowArgumentExceptionTest()
    {
        var expressions = File.ReadAllLines("../../../../BinaryExpressionTree.Tests/TestFalse.txt");
        foreach (var expression in expressions)
        {
            Assert.Throws<ArgumentException>(() => new BinaryExpressionTree(expression));
        }
    }

    private static IEnumerable<TestCaseData> ZeroDivisionCaseDatas
        => new TestCaseData[] 
        {
            new TestCaseData("(/ 10 0)"),
            new TestCaseData("(/ 0 0)")
        };

    [TestCaseSource(nameof(ZeroDivisionCaseDatas))]
    public void ZeroDivisionCasesShouldThrowDivideByZeroExceptionTest(string expression)
    {
        var tree = new BinaryExpressionTree(expression);
        Assert.Throws<DivideByZeroException>(() => tree.CountExpression());
    }

    [Test]
    public void EmptyExpressionShouldCauseArgumentNullExceptionTest()
    {
        Assert.Throws<ArgumentException>(() => new BinaryExpressionTree(String.Empty));
    }
    
    [Test]
    public void TestPrint()
    {
        var expressions = File.ReadAllLines("../../../../BinaryExpressionTree.Tests/TestTruth.txt");
        foreach (var expression in expressions)
        {
            var tree = new BinaryExpressionTree(expression);
            var result = new StringBuilder();
            tree.PrintExpression(false, ref result);
            Assert.That(String.Compare(result.ToString(), expression), Is.EqualTo(0));
        }
    }
}