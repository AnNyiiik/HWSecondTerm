namespace TestCalculator;
public class Tests
{
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
            new TestCaseData((new string[] {"0", "/", "0", "="}, 0.0)),
            new TestCaseData((new string[] {"100", "+", "0", "="}, 100.0)),
            new TestCaseData((new string[] {"100", "-", "0", "="}, 100.0)),
            new TestCaseData((new string[] {"100", "*", "0", "="}, 100.0)),
            new TestCaseData((new string[] {"100", "/", "0", "="}, "Error")),
        };

    [TestCaseSource(nameof(DataCheckBasicCases))]
    public void TestBasicCases(string[] data, double answer)
    {
        //var calculator = new
    }
}