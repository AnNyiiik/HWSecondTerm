using System;

namespace HW1_BWT;

public static class BWT 
{
    public static Tuple<bool, string?, int> Encode(string? sequence)
    {
        if (String.IsNullOrEmpty(sequence))
        {
            return Tuple.Create(false, sequence, 0);
        }

        if (sequence.Length == 1)
        {
            return Tuple.Create(true, sequence, 0);
        }
        var permutationsPositions = new int[sequence.Length];
        for (var i = 0; i < sequence.Length; ++i)
        {
            permutationsPositions[i] = i;
        }
        SortPermutations(permutationsPositions, sequence);
        var encodedSequence = new char[sequence.Length];
        var position = 0;
        for (var i = 0; i < sequence.Length; ++i) 
        {
            encodedSequence[i] = sequence[(sequence.Length - 1 + permutationsPositions[i]) % sequence.Length];
            if (permutationsPositions[i] == 0)
            {
                position = i;
            }
        }

        return Tuple.Create(true, new string(encodedSequence), position);
    }

    public static Tuple<bool, string> Decode(string? sequence, int position)
    {
        
        if (String.IsNullOrEmpty(sequence))
        {
            return Tuple.Create(false, sequence);
        }
        
        if (sequence.Length == 1)
        {
            return Tuple.Create(true, sequence);
        }

        if (position >= sequence.Length)
        {
            return Tuple.Create(false, sequence);
        }
        var cardinality = GetCardinality(sequence);
        var pair = GetAlphabeticFrequencySequence(sequence, cardinality); 
        var firstColum = new char[sequence.Length];
        Array.Copy(sequence.ToCharArray(), firstColum, sequence.Length);
        SortCharacters(firstColum);
        var place = 0;
        for (var i = 0; i < cardinality; ++i)
        {
            place += pair.Item1[i];
            pair.Item1[i] = place - pair.Item1[i];
        }

        var vector = new int[sequence.Length];
        for (var i = 0; i < sequence.Length; ++i)
        {
            var index = GetAlphabetPosition(pair.Item2, sequence[i]);
            vector[pair.Item1[index]] = i;
            ++pair.Item1[index];
        }

        var currentPosition = vector[position];
        var result = new char[sequence.Length];
        for (var i = 0; i < sequence.Length; ++i)
        {
            result[i] = sequence[currentPosition];
            currentPosition = vector[currentPosition];
        }

        return Tuple.Create(true, new string(result));
    }

    private static int GetCardinality(string sequence)
    {
        var sorted = new char[sequence.Length];
        Array.Copy(sequence.ToCharArray(), sorted, sequence.Length);
        SortCharacters(sorted);
        var cardinality = (sequence.Length > 0) ?  1 : 0;
        for (var i = 0; i < sequence.Length - 1; ++i)
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
        for (var i = 0; i < alphabet.Length; ++i)
        {
            if (alphabet[i] == character)
            {
                return i;
            }
        }

        return -1;
    }

    // Returns a pair of int and char arrays: int array contains 1st positions of characters in the sorted sequence,
    //      char array contains the alphabet of the sequence.
    private static Tuple<int[], char[]> GetAlphabeticFrequencySequence(string sequence, int cardinality)
    {
        var index = 0;
        var count = 0; 
        var firstPositionsOfSortedCharacters = new int[cardinality];
        var alphabet = new char[cardinality];
        var sorted = new char[sequence.Length];
        Array.Copy(sequence.ToCharArray(), sorted, sequence.Length);
        SortCharacters(sorted);
        for (var i = 0; i < sequence.Length - 1; ++i)
        {
            if (sorted[i] == sorted[i + 1])
            {
                ++count;
            }
            else
            {
                alphabet[index] = sorted[i];
                firstPositionsOfSortedCharacters[index] = count + 1;
                count = 0;
                ++index;
            }
        }
        alphabet[index] = sorted[sequence.Length - 1];
        firstPositionsOfSortedCharacters[index] = count + 1;
        return new Tuple<int[], char[]>(firstPositionsOfSortedCharacters, alphabet);
    }
    
    private static void SortPermutations(int[] array, string zeroPermutation) 
    {
        for (var i = 1; i < array.Length; i++)
        {
            var index = i - 1;
            while(index >= 0 && ComparePermutations(array[index + 1], array[index], zeroPermutation))
            {
                (array[index + 1], array[index]) = (array[index], array[index + 1]);
                index--;
            }
        }
    }

    private static void SortCharacters(char[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var index = i - 1;
            while(index >= 0 && array[index + 1] < array[index])
            {
                (array[index + 1], array[index]) = (array[index], array[index + 1]);
                index--;
            }
        }
    }

    private static bool ComparePermutations(int first, int second, string sequenceZero)
    {
        var firstPermutation = String.Concat(sequenceZero.Substring(first), 
            sequenceZero.Substring(0, first));
        var secondPermutation = String.Concat(sequenceZero.Substring(second), 
            sequenceZero.Substring(0, second));
        return String.Compare(firstPermutation, secondPermutation) < 0;
    }
}