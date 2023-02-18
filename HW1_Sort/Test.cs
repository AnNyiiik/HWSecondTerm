namespace HW1_Sort
{
    public class Test
    {
        public static bool TestSort()
        {
            int[] emptyCase = new int[0];
            try
            {
                Sort.InsertionSort(emptyCase);
            }
            catch
            {
                return false;
            }

            int[] oneElementCase = { 1 };
            Sort.InsertionSort(oneElementCase);
            if (oneElementCase[0] != 1)
            {
                return false;
            }

            int[] casualCase = { 100, -12, 7, 19, 0, -3, -24, -8, 77, 17, 12, 13, 13, -100 };
            int[] correctSequence = { -100, -24, -12, -8, -3, 0, 7, 12, 13, 13, 17, 19, 77, 100 };
            Sort.InsertionSort(casualCase);
            for (int i = 0; i < casualCase.Length; ++i)
            {
                if (casualCase[i] != correctSequence[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}