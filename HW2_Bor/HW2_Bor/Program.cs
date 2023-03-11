using HW2_Bor;

if (!Test.TestTrie())
{
    Console.WriteLine("Tests have been failed.");
    return;
}

Console.WriteLine("To add an element press 1\nTo remove press 2\nTo check if the particular word contains press 3\n" +
                        "To count words with the same prefix press 4\nTo quit press 0");
var isNumber = Int32.TryParse(Console.ReadLine(), out var number);
if (!isNumber)
{
    Console.WriteLine("Not a number");
    return;
}

if (number > 4 || number < 0)
{
    Console.WriteLine("Incorrect option");
    return;
}

var trie = new Trie();
while (number != 0)
{
    switch (number)
    {
        case 1:
            Console.WriteLine("Enter a word:\n");
            var word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("A null-reference");
                return;
            }
            var isAdded = trie.Add(word);
            if (isAdded)
            {
                Console.WriteLine("A new word has been just added");
            }
            else
            {
                Console.WriteLine("A word hasn't been added, it already exists");
            }
    
            break;
        case 2:
            Console.WriteLine("Enter a word:\n");
            word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("A null-reference");
                return;
            }
            var isDeleted = trie.Remove(word);
            if (isDeleted)
            {
                Console.WriteLine("A word has been just deleted");
            }
            else
            {
                Console.WriteLine("A word hasn't been deleted, it didn't exist");
            }
    
            break;
        
        case 3:
            Console.WriteLine("Enter a word:\n");
            word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("A null-reference");
                return;
            }
            var isExists = trie.Contains(word);
            if (isExists)
            {
                Console.WriteLine("A word exists in the trie");
            }
            else
            {
                Console.WriteLine("A word doesn't exist in the trie");
            }
    
            break;
        
        case 4:
            Console.WriteLine("Enter a prefix:\n");
            word = Console.ReadLine();
            if (word == null)
            {
                Console.WriteLine("A null-reference");
                return;
            }
            var count = trie.HowManyStartsWithPrefix(word);
            Console.WriteLine("{0} words start with {1}\n", count, word);
            break;
    
    }
    Console.WriteLine("Enter an option\n");
    isNumber = Int32.TryParse(Console.ReadLine(), out number);
    if (!isNumber)
    {
        Console.WriteLine("Not a number");
        return;
    }

    if (number > 4 || number < 0)
    {
        Console.WriteLine("Incorrect option");
        return;
    }
}