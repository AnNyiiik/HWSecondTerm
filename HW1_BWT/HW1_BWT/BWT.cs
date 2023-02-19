using System;
using System.Linq;

namespace HW1_BWT
{
    public class BWT
    {
        private static int POSITION = 0;
        
        public static string Encode(string sequence)
        {
            int[] permutationsPositions = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i)
            {
                permutationsPositions[i] = i;
            }
            InsertionSort(permutationsPositions, sequence);
            char[] decodedSequence = new char[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i) //проверить этот цикл
            {
                decodedSequence[i] = sequence[sequence.Length - 1 - permutationsPositions[i]];
                if (permutationsPositions[i] == 0)
                {
                    POSITION = i;
                }
            }

            return String.Join("", decodedSequence);
        }

        public static void Decode(string sequence, int position)
        {
            
        }
        
        static void InsertionSort(int[] array, string zeroPermutation) //проверить сортировку
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i - 1;
                while(index >= 0 && ComparePermutations(array[index + 1], array[index], zeroPermutation))
                {
                    array[index + 1] = array[index + 1] ^ array[index];
                    array[index] = array[index] ^ array[index + 1];
                    array[index + 1] = array[index + 1] ^ array[index];
                    index--;
                }
            }
        }

        static bool ComparePermutations(int first, int second, string sequenceZero)
        {
            string firstPermutation = String.Concat(sequenceZero.Substring(first), 
                sequenceZero.Substring(0, first));
            string secondPermutation = String.Concat(sequenceZero.Substring(second), 
                sequenceZero.Substring(0, second));
            return String.Compare(firstPermutation, secondPermutation) < 0;
        }
    }
}