namespace HW2_Bor;

public static class Test
{
    private static readonly string[] TestData =  { "abab", "babab", "aba", "absa", "babo"};
    private static Trie? MakeTrieFromTestData()
    {
        var trie = new Trie();
        foreach (var word in TestData)
        {
            try
            {
                trie.Add(word);
            }
            catch 
            {
                return null;
            }
        }
        return trie;
    }
    
    private static bool TestAdd()
    {
        var trie = new Trie();
        foreach (var word in TestData)
        {
            try
            {
                var isAdded = trie.Add(word);
                if (!isAdded)
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        return true;
    }

    private static bool TestRemove()
    {
        var trie = MakeTrieFromTestData();
        if (trie == null)
        {
            return false;
        }
        foreach (var word in TestData)
        {
            try
            {
                var isDeleted = trie.Remove(word);
                if (!isDeleted)
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
        return true;
    }

    private static bool TestContains()
    {
        var trie = MakeTrieFromTestData();
        if (trie == null)
        {
            return false;
        }
        foreach (var word in TestData)
        {
            if (!trie.Contains(word))
            {
                return false;
            }
        }

        return true;
    }

    private static bool TestHowManyStartsWithPrefix()
    {
        var trie = MakeTrieFromTestData();
        if (trie == null)
        {
            return false;
        }
        Tuple<string, int>[] prefixes = { Tuple.Create("aba", 2), Tuple.Create("ab", 3), Tuple.Create("bab", 2) };
        foreach (var prefix in prefixes)
        {
            if (trie.HowManyStartsWithPrefix(prefix.Item1) != prefix.Item2)
            {
                return false;
            }
        }

        return true;
    }

    public static bool TestTrie()
    {
        return TestAdd() && TestRemove() && TestContains() && TestHowManyStartsWithPrefix();
    }
}