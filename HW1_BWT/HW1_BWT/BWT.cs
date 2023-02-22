using System;
using System.Linq;

namespace HW1_BWT
{
    public class BWT
    {
        private static int POSITION = 0;
        
        public static string Encode(string sequence)
        {
            if (sequence.Length <= 1)
            {
                return sequence;
            }
            int[] permutationsPositions = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i)
            {
                permutationsPositions[i] = i;
            }
            SortPermutations(permutationsPositions, sequence);
            char[] encodedSequence = new char[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i) 
            {
                encodedSequence[i] = sequence[(sequence.Length - 1 + permutationsPositions[i]) % sequence.Length];
                if (permutationsPositions[i] == 0)
                {
                    POSITION = i;
                }
            }

            return String.Join("", encodedSequence);
        }

        public static string Decode(string sequence)
        {
            if (sequence.Length <= 1)
            {
                return sequence;
            }
            int cardinality = GetCardinality(sequence);
            int[] firstPositionsOfSortedCharacters = new int[cardinality];
            char[] alphabet = new char[cardinality];
            GetAlphabeticFrequencySequence(sequence, firstPositionsOfSortedCharacters, alphabet);
            char[] firstColum = new char[sequence.Length];
            Array.Copy(sequence.ToCharArray(), firstColum, sequence.Length);
            SortCharacters(firstColum);
            int place = 0;
            for (int i = 0; i < cardinality; ++i)
            {
                place += firstPositionsOfSortedCharacters[i];
                firstPositionsOfSortedCharacters[i] = place - firstPositionsOfSortedCharacters[i];
            }

            int[] vector = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i)
            {
                int index = GetAlphabetPosition(alphabet, sequence[i]);
                vector[firstPositionsOfSortedCharacters[index]] = i;
                ++firstPositionsOfSortedCharacters[index];
            }

            int currentPosition = vector[POSITION];
            char[] result = new char[sequence.Length];
            for (int i = 0; i < sequence.Length; ++i)
            {
                result[i] = sequence[currentPosition];
                currentPosition = vector[currentPosition];
            }

            return String.Join("", result);
        }

        private static int GetCardinality(string sequence)
        {
            char[] sorted = new char[sequence.Length];
            Array.Copy(sequence.ToCharArray(), sorted, sequence.Length);
            SortCharacters(sorted);
            int cardinality = (sequence.Length > 0) ?  1 : 0;
            for (int i = 0; i < sequence.Length - 1; ++i)
            {
                if (sorted[i] != sorted[i + 1])
                {
                    ++cardinality;
                }
            }

            return cardinality;
        }

        private static int GetAlphabetPosition(char[] alphabet, char character)
        {
            for (int i = 0; i < alphabet.Length; ++i)
            {
                if (alphabet[i] == character)
                {
                    return i;
                }
            }

            return -1;
        }

        private static void GetAlphabeticFrequencySequence(string sequence, int[] frequency, char[] alphabet)
        {
            int index = 0;
            int count = 0; 
            char[] sorted = new char[sequence.Length];
            Array.Copy(sequence.ToCharArray(), sorted, sequence.Length);
            SortCharacters(sorted);
            for (int i = 0; i < sequence.Length - 1; ++i)
            {
                if (sorted[i] == sorted[i + 1])
                {
                    ++count;
                }
                else
                {
                    alphabet[index] = sorted[i];
                    frequency[index] = count + 1;
                    count = 0;
                    ++index;
                }
            }
            alphabet[index] = sorted[sequence.Length - 1];
            frequency[index] = count + 1;
        }
        
        private static void SortPermutations(int[] array, string zeroPermutation) 
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

        private static void SortCharacters(char[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i - 1;
                while(index >= 0 && array[index + 1] < array[index])
                {
                    (array[index + 1], array[index]) = (array[index], array[index + 1]);
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