using FindSecond;

namespace TestGame
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> TestData
            => new TestCaseData[] {
                new TestCaseData(new int[][] {new int[] {1, 2, 7, 5 }, new int[] {3, 6, 8, 1},
                    new int[] {2, 5, 4, 6}, new int[] {7, 3, 4, 8} })
            };

        [TestCaseSource(nameof(TestData))]
        public void Test1(int[][] testData)
        {
            
        }
    }
}