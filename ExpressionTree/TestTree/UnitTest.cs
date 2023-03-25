using System.Text;
using ExpressionTree;

namespace TestTree;

public class Tests
{
    [Test]
    public void TestTrueCases()
    {
        var expressions = File.ReadAllLines("../../../../TestTree/TestTruth.txt");
        var answers = File.ReadAllLines("../../../../TestTree/testTruthAnswers.txt");
        var index = 0;
        foreach (var expression in expressions)
        {
            var tree = new BinaryExpressionTree(expression);
            var result = tree.Count();
            Double correctAnswer;
            Double.TryParse(answers[index], out correctAnswer);
            Assert.That(result, Is.EqualTo(correctAnswer));
            ++index;
        }
    }

    [Test]
    public void TestCasesWithIncorrectExpressionSholdThrowArgumentException()
    {
        var expressions = File.ReadAllLines("../../../../TestTree/TestFalse.txt");
        foreach (var expression in expressions)
        {
            Assert.Throws<ArgumentException>(() => new BinaryExpressionTree(expression));
        }
    }

    [Test]
    public void EmptyExpressionSholdCauseAgrumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new BinaryExpressionTree(null));
    }

    [Test]
    public void TestPrint()
    {
        var expressions = File.ReadAllLines("../../../../TestTree/TestTruth.txt");
        foreach (var expression in expressions)
        {
            var tree = new BinaryExpressionTree(expression);
            var result = new StringBuilder();
            tree.PrintExpression(false, ref result);
            Assert.That(String.Compare(result.ToString(), expression), Is.EqualTo(0));
        }
    }
}