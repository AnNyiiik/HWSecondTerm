using HW2_Bor;

var bor = new Trie();
bor.Add("abab");
bor.Add("aba");
bor.Add("absa");
var l = bor.Contains("ab");
bor.Remove("aba");
l = bor.Contains("aba");
l = bor.Contains("ababa");
Console.WriteLine(bor.HowManyStartsWithPrefix("ab"));