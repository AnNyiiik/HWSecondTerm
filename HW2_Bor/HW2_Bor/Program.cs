using HW2_Bor;

if (!Test.TestTrie())
{
    Console.WriteLine("Tests have been failed.");
    return;
}

Console.WriteLine("""
    To add an element press 1
    To remove press 2
    To check if the particular word contains press 3
    To count words with the same prefix press 4
    To quit press 0
    """);
var isNumber = Int32.TryParse(Console.ReadLine(), out var number);
if (!isNumber)
{
    Console.WriteLine("Not a number");
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
            if (String.IsNullOrEmpty(word))
            {
                Console.WriteLine("An empty string");
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
            if (String.IsNullOrEmpty(word))
            {
                Console.WriteLine("An empty string");
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
            if (String.IsNullOrEmpty(word))
            {
                Console.WriteLine("An empty string");
                return;
            }
            var exists = trie.Contains(word);
            if (exists)
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
            if (String.IsNullOrEmpty(word))
            {
                Console.WriteLine("An empty string");
                return;
            }
            var count = trie.HowManyStartsWithPrefix(word);
            Console.WriteLine("{0} words start with {1}\n", count, word);
            break;
        default:
            Console.WriteLine("Incorrect option");
            return;
    
    }
    Console.WriteLine("Enter an option\n");
    isNumber = Int32.TryParse(Console.ReadLine(), out number);
    if (!isNumber)
    {
        Console.WriteLine("Not a number");
        return;
    }
}